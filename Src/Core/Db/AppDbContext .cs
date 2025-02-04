using Microsoft.EntityFrameworkCore;
using SistemaPOS.Src.Domain.Entities;

namespace SistemaPOS.Src.Core.Db
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Geo> Geos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<PaymentInfo> PaymentInfos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();

            modelBuilder.Entity<Client>()
                .OwnsOne(u => u.Address, address =>
                {
                    address.OwnsOne(a => a.Geo);
                })
                .OwnsOne(u => u.Company);

            modelBuilder.Entity<Product>()
                .OwnsOne(u => u.Rating);

            modelBuilder.Entity<Order>()
                .OwnsOne(u => u.ShippingAddress);

            modelBuilder.Entity<Order>()
                .OwnsOne(u => u.PaymentInfo);

            modelBuilder.Entity<OrderDetail>()
            .HasKey(u => u.ProductId);

            modelBuilder.Entity<Order>()
                .HasMany(u => u.OrderDetails)
                .WithOne()
                .HasForeignKey(u => u.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            UserSeeds(modelBuilder);
        }

        protected void UserSeeds(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new {Id = 1, Username = "admin", Password = "12qw"});
        }

        public static string Route(string nameDb)
        {
            string path = string.Empty;

            if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                path = Path.Combine(path, nameDb);
            }
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path = Path.Combine(path, "..", "Library", nameDb);
            }

            return path;
        }
    }
}
