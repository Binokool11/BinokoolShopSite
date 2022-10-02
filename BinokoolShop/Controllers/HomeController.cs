using BinokoolShop.Models.Repository.InterfaceRepository;
using Microsoft.AspNetCore.Mvc;
namespace BinokoolShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGuitarRepository guitar;
        public HomeController(IGuitarRepository _guitars)
        {
            guitar = _guitars;
        }
        public IActionResult Main()
        {
            return View(guitar.GetGuitars());
        }
    }
}
