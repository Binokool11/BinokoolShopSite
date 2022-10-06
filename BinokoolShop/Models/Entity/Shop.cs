using BinokoolShop.Models.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace BinokoolShop.Models.Entity
{
    public class Shop
    {
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ShopCartItems { get; set; }
        private readonly ApplicationDbContext dbContext;
        public Shop(ApplicationDbContext _context)
        {
            dbContext = _context;
        }

        public static Shop GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();
            string shopCartId = session.GetString("CartId")?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new Shop(context) { ShopCartId = shopCartId};
        }
        //Добавить логику повторного добавления
        public void AddToCart(Guitar guitar, int quantity)
        {
            dbContext.shops.Add(new ShopCartItem { ShopCartId = ShopCartId,  Guitar = guitar, Quantity = quantity});
            dbContext.SaveChanges();
        }

        public List<ShopCartItem> GetShopCartItems()
        {
            return dbContext.shops.Where(c => c.ShopCartId == ShopCartId).Include(c => c.Guitar).ToList();
        }
    }
}
