using SistemaPOS.Src.Core.Services.ViewModels;
using SistemaPOS.Src.Presentation.ViewModels;

namespace SistemaPOS.Src.Presentation.Pages;

public partial class ClientPage : ContentPage
{
	public ClientPage(ClientViewModel userViewModel)
    {
        NavigationPage.SetBackButtonTitle(this, string.Empty);
        BindingContext = userViewModel;
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is not IViewModel ivm)
        {
            return;
        }

        await ivm.InitializeAsyncCommand.ExecuteAsync(null);
    }
}