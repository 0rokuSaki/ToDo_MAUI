using CommunityToolkit.Mvvm.Input;
using ToDo_MAUI.Repositories;
using ToDo_MAUI.Views;

namespace ToDo_MAUI.ViewModels;

public partial class MainViewModel : ViewModel
{
    private readonly IToDoItemRepository _repository;

    private readonly IServiceProvider _serviceProvider;

    public MainViewModel(IToDoItemRepository repository, IServiceProvider serviceProvider)
    {
        _repository = repository;
        _serviceProvider = serviceProvider;
        Task.Run(async () => await LoadDataAsync());
    }

    [RelayCommand]
    public async Task AddItemAsync() =>
        await Navigation.PushAsync(_serviceProvider.GetRequiredService<ItemView>());

    private async Task LoadDataAsync()
    {
    }
}
