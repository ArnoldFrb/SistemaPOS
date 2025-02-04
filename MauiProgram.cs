using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Refit;
using SistemaPOS.Src.Core.Api;
using SistemaPOS.Src.Core.Db;
using SistemaPOS.Src.Core.Services.Dialogs;
using SistemaPOS.Src.Core.Services.Navigation;
using SistemaPOS.Src.Data.Dao;
using SistemaPOS.Src.Data.Repositories.Api;
using SistemaPOS.Src.Data.Repositories.Dao;
using SistemaPOS.Src.Data.Services;
using SistemaPOS.Src.Domain.Contracts.Dao;
using SistemaPOS.Src.Domain.Contracts.Repositories.Api;
using SistemaPOS.Src.Domain.Contracts.Repositories.Dao;
using SistemaPOS.Src.Domain.Contracts.Services;
using SistemaPOS.Src.Domain.Contracts.UseCase;
using SistemaPOS.Src.Domain.UseCase;
using SistemaPOS.Src.Presentation.Pages;
using SistemaPOS.Src.Presentation.ViewModels;

namespace SistemaPOS
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            var regisster = Register.RegisterCore(builder)
                .RegisterApiClient()
                .RegisterDbContext()
                .RegisterServices()
                .RegisterDao()
                .RegisterRepositories()
                .RegisterUseCases()
                .RegisterViewModels()
                .RegisterPages();

            return regisster.Build();
        }
    }

    public static class Register
    {
        public static MauiAppBuilder RegisterCore(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<IDialogService, DialogService>();

            return builder;
        }

        public static MauiAppBuilder RegisterApiClient(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<HttpLoggingHandler>();
            builder.Services.AddRefitClient<IApiUser>().ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                client.Timeout = TimeSpan.FromSeconds(60);
            }).AddHttpMessageHandler(provider => new HttpLoggingHandler(provider.GetRequiredService<ILogger<HttpLoggingHandler>>()));

            builder.Services.AddRefitClient<IApiProduct>().ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri("https://fakestoreapi.com");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                client.Timeout = TimeSpan.FromSeconds(60);
            }).AddHttpMessageHandler(provider => new HttpLoggingHandler(provider.GetRequiredService<ILogger<HttpLoggingHandler>>()));

            return builder;
        }

        public static MauiAppBuilder RegisterDbContext(this MauiAppBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite($"Filename={AppDbContext.Route("system_pos.db")}"));

            return builder;
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IClientService, ClientService>();
            builder.Services.AddSingleton<IProductService, ProductService>();
            return builder;
        }

        public static MauiAppBuilder RegisterDao(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IUserDao, UserDao>();
            builder.Services.AddSingleton<IClientDao, ClientDao>();
            builder.Services.AddSingleton<IProductDao, ProductDao>();
            builder.Services.AddSingleton<IOrderDao, OrderDao>();
            builder.Services.AddSingleton<IBasketDao, BasketDao>();
            return builder;
        }

        public static MauiAppBuilder RegisterRepositories(this MauiAppBuilder builder)
        {
            // API
            builder.Services.AddSingleton<IClientApiRepository, ClientApiRepository>();
            builder.Services.AddSingleton<IProductApiRepository, ProductApiRepository>();

            //DB
            builder.Services.AddSingleton<IUserDbRepository, UserDbRepository>();
            builder.Services.AddSingleton<IClientDbRepository, ClientDbRepository>();
            builder.Services.AddSingleton<IProductDbRepository, ProductDbRepository>();
            builder.Services.AddSingleton<IOrderDbRepository, OrderDbRepository>();
            builder.Services.AddSingleton<IBasketDbRepository, BasketDbRepository>();

            return builder;
        }

        public static MauiAppBuilder RegisterUseCases(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IGetUserUseCase, GetUserUseCase>();
            builder.Services.AddSingleton<IGetClientUseCase, GetClientUseCase>();
            builder.Services.AddSingleton<IGetProductUseCase, GetProductUseCase>();
            builder.Services.AddSingleton<IGetOrderUseCase, GetOrderUseCase>();
            builder.Services.AddSingleton<IGetBasketUseCase, GetBasketUseCase>();
            return builder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<ClientViewModel>();
            builder.Services.AddTransient<ProductViewModel>();
            return builder;
        }

        public static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<ClientPage>();
            builder.Services.AddTransient<ProductPage>();
            builder.Services.AddTransient<BasketPage>();
            return builder;
        }
    }
}