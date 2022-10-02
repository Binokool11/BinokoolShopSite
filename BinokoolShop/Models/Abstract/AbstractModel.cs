using System.ComponentModel.DataAnnotations;

namespace BinokoolShop.Models.Abstract
{
    public abstract class AbstractModel
    {
        [Required]
        public virtual Guid Id { get; set; }
        [Display(Name = "Название")]
        public virtual string Name { get; set; } = "";
        [Display(Name = "Цена")]
        public virtual decimal Price { get; set; } = 0M;
        [Display(Name = "Короткое описание")]
        public virtual string ShortText { get; set; } = "";
        [Display(Name = "Полное описание")]
        public virtual string LongText { get; set; } = "";
        [Display(Name = "В наличии")]
        public virtual bool IsAvaible { get; set; } = false;
        [Display(Name = "Количество")]
        public virtual int Count { get; set; } = 0;
        [Display(Name = "Картинка")]
        public virtual string Img { get; set; } = "";


    }
}
