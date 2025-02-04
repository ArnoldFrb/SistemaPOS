using CommunityToolkit.Mvvm.Input;
using SistemaPOS.Src.Core.Services.Navigation;

namespace SistemaPOS.Src.Core.Services.ViewModels
{
    public interface IViewModel : IQueryAttributable
    {
        public INavigationService NavigationService { get; }
        public IAsyncRelayCommand InitializeAsyncCommand { get; }
        public bool IsBusy { get; }
        public bool IsInitialized { get; }
        Task InitializeAsync();
    }
}
