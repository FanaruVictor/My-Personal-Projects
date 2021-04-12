using CupcakeShop.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace CupcakeShop.Web.Data
{
    public class CupcakeShopDbContext : DbContext
    {
        public CupcakeShopDbContext(DbContextOptions<CupcakeShopDbContext> options) : base(options)
        {
        }

        public CupcakeShopDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CupcakeOrder>().HasKey(sc => new {sc.CupcakeId, sc.OrderId});
            modelBuilder.Entity<CupcakeCandy>().HasKey(sc => new {sc.CupcakeId, sc.CandyId});
            modelBuilder.Entity<CupcakeCart>().HasKey(sc => new {sc.CupcakeId, sc.CartId});
        }


        public DbSet<Cupcake> Cupcakes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Candy> Candies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CupcakeOrder> CupcakeOrders { get; set; }
        public DbSet<CupcakeCandy> CupcakeCandies { get; set; }
        public DbSet<CupcakeCart> CupcakeCarts { get; set; }
    }
}
