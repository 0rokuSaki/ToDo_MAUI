using ToDo_MAUI.Repositories;

namespace ToDo_MAUI.ViewModels;

public class MainViewModel : ViewModel
{
    private readonly IToDoItemRepository _repository;

    public MainViewModel(IToDoItemRepository repository)
    {
        _repository = repository;
        Task.Run(async () => await LoadDataAsync());
    }

    private async Task LoadDataAsync()
    {
    }
}
