using ToDo_MAUI.ViewModels;

namespace ToDo_MAUI.Views;

public partial class ItemView : ContentPage
{
	public ItemView(ItemViewModel viewModel)
	{
		InitializeComponent();
		viewModel.Navigation = Navigation;
		BindingContext = viewModel;
	}
}