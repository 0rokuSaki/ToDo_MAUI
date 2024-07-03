using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace ToDo_MAUI.ViewModels;

public abstract partial class ViewModel : ObservableObject
{
    public INavigation Navigation { get; set; }
}
