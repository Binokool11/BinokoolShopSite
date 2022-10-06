using BinokoolShop.Models.Repository.InterfaceRepository;
using BinokoolShop.ViewModel;
using Microsoft.AspNetCore.Mvc;
namespace BinokoolShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGuitarRepository guitars;
        public HomeController(IGuitarRepository _guitars)
        {
            guitars = _guitars;
        }
        public IActionResult Main()
        {
            return View(guitars.GetGuitars());
        }



        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel { guitarsViewModel = guitars.GetGuitars() };
            return View(homeViewModel);
        }
    }
}
