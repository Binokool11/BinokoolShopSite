using BinokoolShop.Models;
using BinokoolShop.Models.Entity;
using BinokoolShop.Models.Repository.InterfaceRepository;
using BinokoolShop.ViewModel;
using Microsoft.AspNetCore.Mvc;
namespace BinokoolShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGuitarRepository guitars;
        private readonly ICategoryRepository categories;
        public HomeController(IGuitarRepository _guitars, ICategoryRepository _category)
        {
            guitars = _guitars;
            categories = _category;
        }
        public IActionResult Main()
        {

            return View(guitars.GetGuitars());
        }
        public IActionResult Category(string category)
        {
            if (string.IsNullOrEmpty(category)) { throw new ArgumentNullException(); }
            IEnumerable<Guitar> guitarsWithCurrentCategory;
            if (category == "Все гитары")
            {
                guitarsWithCurrentCategory = guitars.GetGuitars().OrderBy(guitar => guitar.Price);
                return RedirectToAction("Main", guitarsWithCurrentCategory);
            }
            else
            {
                guitarsWithCurrentCategory = guitars.GetGuitars().Where(p => p.Category.CategoryName == category).OrderBy(guitar => guitar.Name);
                GuitarsViewModel guitarsViewModel = new GuitarsViewModel { guitars = guitarsWithCurrentCategory, Category = category };
                return View("Category", guitarsViewModel);
            }
        }
    }
}
