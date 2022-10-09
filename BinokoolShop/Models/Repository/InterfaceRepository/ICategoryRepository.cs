using BinokoolShop.Models.Entity;

namespace BinokoolShop.Models.Repository.InterfaceRepository
{
    public interface ICategoryRepository
    {
        void SetCategorys();
        IQueryable<Category> GetCategorys();
    }
}
