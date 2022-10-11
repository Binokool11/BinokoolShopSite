using BinokoolShop.Models.AppDbContext;
using BinokoolShop.Models.Repository.InterfaceRepository;
using Microsoft.EntityFrameworkCore;

namespace BinokoolShop.Models.Entity
{
    public class ShopRepository
    {
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ShopCartItems { get; set; }
        private readonly ApplicationDbContext dbContext;
        public ShopRepository(ApplicationDbContext _context)
        {
            dbContext = _context;
        }

        public static ShopRepository GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();
            string shopCartId = session.GetString("CartId")?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopRepository(context) { ShopCartId = shopCartId};
        }

        public void SetCartList(List<ShopCartItem> shopCartItems)
        {
            ShopCartItems = shopCartItems;
        }
        public void IncreaseGuitar(Guitar guitar)
        {
            ShopCartItem? cart = ShopCartItems.FirstOrDefault(cart => cart.Guitar.Id == guitar.Id);
            cart.Quantity++;
            dbContext.SaveChanges();
        }

        public void AddToCart(Guitar guitar, int quantity)
        {
            dbContext.shops.Add(new ShopCartItem { ShopCartId = ShopCartId, Guitar = guitar, Quantity = quantity });
            dbContext.SaveChanges();
        }


        public List<ShopCartItem> GetShopCartItems()
        {
            return dbContext.shops.Where(c => c.ShopCartId == ShopCartId).Include(c => c.Guitar).ToList();
        }
    }
}
