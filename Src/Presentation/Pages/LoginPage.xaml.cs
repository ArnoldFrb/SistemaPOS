using SistemaPOS.Src.Presentation.ViewModels;

namespace SistemaPOS.Src.Presentation.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel loginViewModel)
    {
        BindingContext = loginViewModel;
        InitializeComponent();
	}
}