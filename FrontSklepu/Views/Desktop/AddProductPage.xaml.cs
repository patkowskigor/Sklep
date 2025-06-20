using FrontSklepu.ViewModels;

namespace FrontSklepu.Views.Desktop;

public partial class AddProductPage : ContentPage
{
	public AddProductPage(AddProductPageViewModel addProductPageViewModel)
	{
        InitializeComponent();
		BindingContext = addProductPageViewModel;
	}
}