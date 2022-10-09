using BinokoolShop.Models.AppDbContext;
using BinokoolShop.Models.Entity;
using BinokoolShop.Models.Repository.InterfaceRepository;

namespace BinokoolShop.Models.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext context;
        public CategoryRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IQueryable<Category> GetCategorys()
        {
            return context.categories;
        }

        public void SetCategorys()
        {
            context.categories.Add(new Category { CategoryName = "Акустическая гитара" });
            context.categories.Add(new Category { CategoryName = "Электрическая гитара" });
            context.SaveChanges();
        }
    }
}
