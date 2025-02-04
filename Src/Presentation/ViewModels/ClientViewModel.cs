using System.Diagnostics;
using SistemaPOS.Src.Core.Services.Dialogs;
using SistemaPOS.Src.Core.Services.Navigation;
using SistemaPOS.Src.Core.Services.ViewModels;
using SistemaPOS.Src.Domain.Contracts.UseCase;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Presentation.ViewModels
{
    public partial class ClientViewModel(INavigationService navigationService, IDialogService dialogService, IGetClientUseCase user) : ViewModel(navigationService)
    {
        private readonly IGetClientUseCase _user = user;
        private readonly IDialogService _dialogService = dialogService;


        private bool _initialized;
        private readonly ObservableCollectionEx<Client> _users = [];

        public IReadOnlyList<Client> Users => _users;

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
                    var regions = await _user.GetAll();
                    Debug.WriteLine(regions);

                    if (regions.IsOkOrError)
                    {
                        IsOk = regions.IsOkOrError;
                        _users.ReloadData(regions.Unwrap());

                        await _dialogService.ShowDialog("Error", regions.Unwrap().Count().ToString(), "Aceptar");
                    }
                    else
                    {
                        IsError = !regions.IsOkOrError;
                        await _dialogService.ShowDialog("Error", regions.UnwrapError().Message, "Aceptar");
                    }
                });
        }
    }
}