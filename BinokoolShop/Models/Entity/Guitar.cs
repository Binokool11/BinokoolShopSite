using BinokoolShop.Models.Abstract;
using BinokoolShop.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace BinokoolShop.Models;

public class Guitar : AbstractModel
{
    [Required]
    [Display(Name = "Название гитары")]
    public override string Name { get; set; } = "";
    public int ItemId { get; set; }
    [Required]
    [Display(Name ="Короткое описание гитары")]
    public override string ShortText { get; set; } = "";
    [Display(Name = "Полное описание гитары")]
    public override string LongText { get; set; } = "";
    public Category Category { get; set; }
}
