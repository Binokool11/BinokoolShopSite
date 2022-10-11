using System.ComponentModel.DataAnnotations;

namespace BinokoolShop.Models.Entity
{
    public class User
    {
        
        public int Id { get; set; }
        [Required (ErrorMessage = "Имя не должно быть пустым")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email не должен быть пуст")]
        public string Email { get; set; }
        [Required (ErrorMessage = "Телефон не должен быть пустым")]
        public string Phone { get; set; }
        public int? UserId { get; set; }
        public List<ShopCartItem>? ShopCartItems { get; set; }

    }
}
