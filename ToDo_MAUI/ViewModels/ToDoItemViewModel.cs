using CommunityToolkit.Mvvm.ComponentModel;
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
}
