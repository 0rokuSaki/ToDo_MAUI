using ToDo_MAUI.ViewModels;

namespace ToDo_MAUI.Views;

public partial class MainView : ContentPage
{
	public MainView(MainViewModel viewModel)
	{
		InitializeComponent();
		viewModel.Navigation = Navigation;
		BindingContext = viewModel;
		ItemsListView.ItemSelected += (sender, e) =>
			this.ItemsListView.SelectedItem = null;
	}
}