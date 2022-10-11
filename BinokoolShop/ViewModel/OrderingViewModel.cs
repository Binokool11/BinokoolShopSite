using BinokoolShop.Models.Entity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BinokoolShop.ViewModel
{
    public class OrderingViewModel
    {
        public ShopRepository shopCart { get; set; }
        public ModelStateDictionary modelError { get; set; } = null;
    }
}
