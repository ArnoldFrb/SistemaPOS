using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SistemaPOS.Src.Core.Services.Navigation;

namespace SistemaPOS.Src.Core.Services.ViewModels
{
    public abstract partial class ViewModel : ObservableObject, IViewModel
    {
        private long _isBusy;

        public bool IsBusy => Interlocked.Read(ref _isBusy) > 0;

        [ObservableProperty]
        private bool _isInitialized;

        [ObservableProperty]
        private bool _isOk;

        [ObservableProperty]
        private bool _isError;

        public INavigationService NavigationService { get; }

        public IAsyncRelayCommand InitializeAsyncCommand { get; }

        public ViewModel(INavigationService navigationService)
        {
            IsOk = false;
            IsError = false;
            NavigationService = navigationService;

            InitializeAsyncCommand = new AsyncRelayCommand(
                async () =>
                {
                    await IsBusyFor(InitializeAsync);
                    IsInitialized = true;
                }, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query) { }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task IsBusyFor(Func<Task> unitOfWork)
        {
            Interlocked.Increment(ref _isBusy);
            OnPropertyChanged(nameof(IsBusy));

            try
            {
                await unitOfWork();
            }
            finally
            {
                Interlocked.Decrement(ref _isBusy);
                OnPropertyChanged(nameof(IsBusy));
            }
        }
    }

}
