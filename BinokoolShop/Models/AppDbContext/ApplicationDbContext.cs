using BinokoolShop.Models.Entity;
using Microsoft.EntityFrameworkCore;
namespace BinokoolShop.Models.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Guitar> guitars { get; set; } = null!;
        public DbSet<ShopCartItem> shops { get; set; } = null!;
        public DbSet<Category> categories { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt ) : base(opt)
        {
        }
    }
}
