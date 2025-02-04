using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SistemaPOS.Src.Core.Services.Dialogs;
using SistemaPOS.Src.Core.Services.Navigation;
using SistemaPOS.Src.Core.Services.ViewModels;
using SistemaPOS.Src.Core.Validations;
using SistemaPOS.Src.Domain.Contracts.UseCase;
using SistemaPOS.Src.Presentation.Pages;

namespace SistemaPOS.Src.Presentation.ViewModels
{
    public partial class LoginViewModel(INavigationService navigationService, IGetUserUseCase user, IDialogService dialogService) : ViewModel(navigationService)
    {
        private readonly IDialogService _dialogService = dialogService;
        private readonly IGetUserUseCase _user = user;

        [ObservableProperty]
        private ValidatableObject<string> _userName = new();

        [ObservableProperty]
        private ValidatableObject<string> _password = new();

        [ObservableProperty]
        private bool _isValid;

        private async Task ToHomeAsync()
        {
            await NavigationService.NavigateToAsync($"///{nameof(ProductPage)}");
        }

        [RelayCommand]
        private void Validate()
        {
            IsValid = UserName.Validate(UserName.GetValue()) && Password.Validate(Password.GetValue());
        }

        [RelayCommand]
        private async Task SignInAsync()
        {
            await IsBusyFor(
                async () =>
                {
                    if (IsValid)
                    {
                        var result = await _user.AuthAsync(UserName.GetValue()!, Password.GetValue()!);
                        if (result.IsOkOrError)
                        {
                            await ToHomeAsync();
                        }
                        else
                        {
                            await _dialogService.ShowDialog("Error", $"[SignIn] Error signing in: {result.UnwrapError().Message}", "Aceptar");
                        }
                    }
                    else
                    {
                        await _dialogService.ShowDialog("Error", "[SignIn] Error signing in: Invalid User", "Aceptar");
                    }
                    
                });
        }
    }
}
