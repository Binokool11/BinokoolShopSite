namespace BinokoolShop.Models.Entity
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Guitar Guitar { get; set; }
        public int Quantity { get; set; }   
        public string ShopCartId { get; set; }
    }
}
