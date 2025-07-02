using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
    }
}
