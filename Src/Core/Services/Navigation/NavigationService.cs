using SistemaPOS.Src.Presentation.Pages;

namespace SistemaPOS.Src.Core.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public Task InitializeAsync()
        {
            return NavigateToAsync($"//{nameof(LoginPage)}");
        }

        public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = default!)
        {
            var shellNavigation = new ShellNavigationState(route);

            return routeParameters != null
                ? Shell.Current.GoToAsync(shellNavigation, routeParameters)
                : Shell.Current.GoToAsync(shellNavigation);
        }

        public Task PopAsync()
        {
            return Shell.Current.GoToAsync("..");
        }

    }
}
