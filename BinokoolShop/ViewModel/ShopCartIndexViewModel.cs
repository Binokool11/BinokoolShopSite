using BinokoolShop.Models.Entity;

namespace BinokoolShop.Views.ShopCart
{
    public class ShopCartIndexViewModel
    {
        public ShopRepository ShopCart { get; set;  }
        public Validation Validation { get; set; } = null;
    }
}
