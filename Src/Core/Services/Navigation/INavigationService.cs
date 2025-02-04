namespace SistemaPOS.Src.Core.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();
        Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = default!);
        Task PopAsync();
    }
}
