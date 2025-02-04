using SistemaPOS.Src.Core.Services.ViewModels;
using SistemaPOS.Src.Presentation.ViewModels;

namespace SistemaPOS.Src.Presentation.Pages;

public partial class ProductPage : ContentPage
{
    public ProductPage(ProductViewModel productViewModel)
    {
        NavigationPage.SetBackButtonTitle(this, string.Empty);
        BindingContext = productViewModel;
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