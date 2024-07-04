using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ToDo_MAUI.Models;
using ToDo_MAUI.Repositories;
using ToDo_MAUI.Views;

namespace ToDo_MAUI.ViewModels;

public partial class MainViewModel : ViewModel
{
    [ObservableProperty]
    private ObservableCollection<ToDoItemViewModel>? _items;

    [ObservableProperty]
    private ToDoItemViewModel? _selectedItem;

    private readonly IToDoItemRepository _repository;

    private readonly IServiceProvider _serviceProvider;

    public MainViewModel(IToDoItemRepository repository, IServiceProvider serviceProvider)
    {
        repository.OnItemAdded += (sender, item) => Items?.Add(CreateToDoItemViewModel(item));
        repository.OnItemUpdated += (sender, item) => Task.Run(async () => await LoadDataAsync());

        _repository = repository;
        _serviceProvider = serviceProvider;
        Task.Run(async () => await LoadDataAsync());
    }

    partial void OnSelectedItemChanging(ToDoItemViewModel? value)
    {
        if (value == null)
        {
            return;
        }
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await NavigateToItemAsync(value);
        });
    }

    private async Task NavigateToItemAsync(ToDoItemViewModel item)
    {
        var itemView = _serviceProvider.GetRequiredService<ItemView>();
        var vm = itemView.BindingContext as ItemViewModel;
        vm!.Item = item.Item;
        itemView.Title = "Edit To Do Item";
        await this.Navigation.PushAsync(itemView);
    }

    [RelayCommand]
    public async Task AddItemAsync() =>
        await Navigation.PushAsync(_serviceProvider.GetRequiredService<ItemView>());

    private async Task LoadDataAsync()
    {
        var items = await _repository.GetItemsAsync();
        var itemViewModels = items.Select(i => CreateToDoItemViewModel(i));
        this.Items = new ObservableCollection<ToDoItemViewModel>(itemViewModels);
    }

    private ToDoItemViewModel CreateToDoItemViewModel(ToDoItem item)
    {
        var itemViewModel = new ToDoItemViewModel(item);
        itemViewModel.ItemStatusChanged += ItemStatusChanged;
        return itemViewModel;
    }

    private void ItemStatusChanged(object? sender, EventArgs e)
    {
    }
}
