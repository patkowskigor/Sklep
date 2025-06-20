using FrontSklepu.ViewModels;

namespace FrontSklepu.Views.Desktop;

public partial class DesktopHomePage : ContentPage
{
	public DesktopHomePage(DesktopHomePageViewModel desktopHomePageViewModel)
	{
		InitializeComponent();
		BindingContext = desktopHomePageViewModel;
	}
}