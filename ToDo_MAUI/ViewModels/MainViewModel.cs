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
