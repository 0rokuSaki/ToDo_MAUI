using ToDo_MAUI.Repositories;

namespace ToDo_MAUI.ViewModels;

public class ItemViewModel : ViewModel
{
    private readonly IToDoItemRepository _repository;

    public ItemViewModel(IToDoItemRepository repository)
    {
        _repository = repository;
    }
}
