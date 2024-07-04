using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDo_MAUI.Models;
using ToDo_MAUI.Repositories;

namespace ToDo_MAUI.ViewModels;

public partial class ItemViewModel : ViewModel
{
    private readonly IToDoItemRepository _repository;

    [ObservableProperty]
    ToDoItem _item;

    public ItemViewModel(IToDoItemRepository repository)
    {
        _repository = repository;
        this.Item = new ToDoItem()
        {
            Due = DateTime.Now.AddDays(1)
        };
    }

    [RelayCommand]
    public async Task SaveAsync()
    {
        await _repository.AddOrUpdateAsync(this.Item);
        await this.Navigation.PopAsync();
    }
}
