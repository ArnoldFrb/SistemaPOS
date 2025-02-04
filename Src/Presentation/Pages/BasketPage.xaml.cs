using SistemaPOS.Src.Presentation.ViewModels;

namespace SistemaPOS.Src.Presentation.Pages;

public partial class BasketPage : ContentPage
{
	public BasketPage(ProductViewModel productViewModel)
    {
        NavigationPage.SetBackButtonTitle(this, string.Empty);
        BindingContext = productViewModel;
        InitializeComponent();
	}
}