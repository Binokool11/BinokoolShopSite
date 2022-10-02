using Microsoft.EntityFrameworkCore;
namespace BinokoolShop.Models.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Guitar> guitars { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt ) : base(opt)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
        }
    }
}
