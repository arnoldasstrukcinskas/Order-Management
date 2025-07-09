using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Order_Management.Data.Entity;

namespace Order_Management.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options)
               : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
    }
}
