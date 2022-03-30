using Microsoft.EntityFrameworkCore;
using TriviumApi.Models.Entities.Customers;
using TriviumApi.Models.Entities.Products;
using TriviumApi.Models.Entities.Purchases;

namespace TriviumApi.Infra
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Map();
            modelBuilder.Entity<Product>().Map();
            modelBuilder.Entity<Purchase>().Map();
            modelBuilder.Entity<PurchaseItem>().Map();
        }

    }
}
