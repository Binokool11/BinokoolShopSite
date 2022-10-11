using BinokoolShop.Models.Entity;

namespace BinokoolShop.Models.Repository.InterfaceRepository
{
    public interface IUserRepository
    {
        void SetUser(User user,List<ShopCartItem> shopCartItems);

        User GetUser(int userId);
        IQueryable<User> GetUsers();
        void Clear();
    
    }
}
