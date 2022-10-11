using BinokoolShop.Models.AppDbContext;
using BinokoolShop.Models.Entity;
using BinokoolShop.Models.Repository.InterfaceRepository;

namespace BinokoolShop.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public User GetUser(int userId)
        {
            User? user = context.users.FirstOrDefault(user => user.UserId == userId);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public IQueryable<User> GetUsers()
        {
            return context.users;
        }

        public void SetUser(User user, List<ShopCartItem> shopCartItems)
        {
            
            user.ShopCartItems = shopCartItems;
            context.users.Add(user);
            context.SaveChanges();
        }

        public void Clear()
        {
            foreach (User user in context.users)
            {
                context.users.Remove(user);
            }
            context.SaveChanges();
        }
    }
}
