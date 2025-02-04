using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SistemaPOS.Src.Core.Messages;
using SistemaPOS.Src.Core.Services.Dialogs;
using SistemaPOS.Src.Core.Services.Navigation;
using SistemaPOS.Src.Core.Services.ViewModels;
using SistemaPOS.Src.Domain.Contracts.UseCase;
using SistemaPOS.Src.Domain.Entities;
using SistemaPOS.Src.Presentation.Pages;

namespace SistemaPOS.Src.Presentation.ViewModels
{
    public partial class ProductViewModel(
        INavigationService navigationService,
        IDialogService dialogService,
        IGetProductUseCase product,
        IGetOrderUseCase order
        ) : ViewModel(navigationService)
    {
        private readonly IGetProductUseCase _product = product;
        private readonly IGetOrderUseCase _order = order;
        private readonly IDialogService _dialogService = dialogService;

        private readonly List<OrderDetail> _basket = [];

        private bool _initialized;
        private readonly ObservableCollectionEx<Product> _products = [];
        private readonly ObservableCollectionEx<Order> _orders = [];

        public IReadOnlyList<Product> Products => _products;
        public IReadOnlyList<Order> Orders => _orders;

        [ObservableProperty]
        private Product _selectedProduct;

        [ObservableProperty]
        private int _badgeCount;

        [ObservableProperty]
        private decimal _total;

        public override async Task InitializeAsync()
        {
            if (_initialized)
            {
                return;
            }

            _initialized = true;

            await IsBusyFor(
                async () =>
                {
                    var pResult = await _product.GetAll();
                    var bResult = await _order.GetAsync();
                    Debug.WriteLine(pResult);

                    if (pResult.IsOkOrError)
                    {
                        IsOk = pResult.IsOkOrError;
                        _products.ReloadData(pResult.Unwrap());
                    }
                    else
                    {
                        IsError = !pResult.IsOkOrError;
                        await _dialogService.ShowDialog("Error", pResult.UnwrapError().Message, "Aceptar");
                    }

                    if (bResult.IsOkOrError)
                    {
                        IsOk = bResult.IsOkOrError;
                        _orders.ReloadData(bResult.Unwrap());
                        BadgeCount = _orders.Count;
                        WeakReferenceMessenger.Default.Send(new AddProductMessage(BadgeCount));
                    }
                    else
                    {
                        IsError = !bResult.IsOkOrError;
                        await _dialogService.ShowDialog("Error", bResult.UnwrapError().Message, "Aceptar");
                    }
                });
        }

        [RelayCommand]
        public void AddCatalogItem(Product product)
        {
            if (product is null)
            {
                return;
            }

            int quantity = 1;
            decimal discount = 0.2M;
            _basket.Add(new OrderDetail(product.Id, (decimal)product.Price, product.Title, product.Image, quantity, discount));

            BadgeCount = _orders.Count;
            WeakReferenceMessenger.Default.Send(new AddProductMessage(BadgeCount));

            Total = _orders?.Sum(o => o.Total) ?? 0m;

            SelectedProduct = null;
        }

        [RelayCommand]
        private async Task ToOrderAsync()
        {
            if (_orders.Count > 0)
            {
                var order = new Order(
                    id: 1,
                    orderStatus: OrderStatus.Submitted,
                    total: Total,
                    shippingAddress: new ShippingAddress(
                        shippingCity: "New York",
                        shippingStreet: "123 Main St",
                        shippingState: "NY",
                        shippingCountry: "USA",
                        shippingZipCode: "10001"
                    ),
                    paymentInfo: new PaymentInfo(
                        cardTypeId: 1,
                        cardNumber: "4111111111111111",
                        cardHolderName: "John Doe",
                        cardExpiration: new DateTime(2026, 12, 31),
                        cardSecurityNumber: "123"
                    ),
                    orderDetails: _basket
                    );

                var bResult = await _order.AddAsync(order);
                Debug.WriteLine(bResult);

                if (bResult.IsOkOrError)
                {
                    await NavigationService.NavigateToAsync(nameof(BasketPage));
                }
                else
                {
                    await _dialogService.ShowDialog("Error", bResult.UnwrapError().Message, "Aceptar");
                }
            }
            else
            {
                await NavigationService.NavigateToAsync(nameof(BasketPage));
            }
        }

        [RelayCommand]
        private async Task ToDialogAsync()
        {
            await _dialogService.ShowDialog("Exito", "Funciona", "Acectar");
        }
    }
}