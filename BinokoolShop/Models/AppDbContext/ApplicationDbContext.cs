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
            model.Entity<Guitar>().HasData(
                new Guitar { 
                    Id = new Guid("75db221d-d327-45a8-9107-c56984b8b710"),
                    Price = 99.9M,
                    ShortText = "Крутая гитара",
                    LongText = "Очень крутая гитара",
                    Name = "Gibson",
                    IsAvaible = true,
                    Count = 10,
                    Img = "~/img/Gibson.jpg"
                });
        }
    }
}
