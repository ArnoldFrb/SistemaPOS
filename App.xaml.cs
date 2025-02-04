using SistemaPOS.Src.Core.Db;
using SistemaPOS.Src.Core.Services.Navigation;

namespace SistemaPOS
{
    public partial class App : Application
    {
        private readonly AppDbContext _dbContext;
        public App(INavigationService navigationService, AppDbContext dbContext)
        {
            InitializeComponent();

            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();

            MainPage = new AppShell(navigationService);
        }
    }
}
