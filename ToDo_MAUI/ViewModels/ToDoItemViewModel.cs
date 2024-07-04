using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDo_MAUI.Models;

namespace ToDo_MAUI.ViewModels;

public partial class ToDoItemViewModel : ViewModel
{
    [ObservableProperty]
    ToDoItem _item;

    public string StatusText => Item.Completed ? "Reactivate" : "Completed";

    public event EventHandler ItemStatusChanged;

    public ToDoItemViewModel(ToDoItem item)
    {
        _item = item;
    }

    [RelayCommand]
    void ToggleCompleted()
    {
        Item.Completed = !Item.Completed;
        ItemStatusChanged?.Invoke(this, EventArgs.Empty);
    }
}
