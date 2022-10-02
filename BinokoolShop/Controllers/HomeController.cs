using BinokoolShop.Models;
using BinokoolShop.Models.Repository.InterfaceRepository;
using Microsoft.AspNetCore.Mvc;
namespace BinokoolShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGuitarRepository guitars;
        private readonly List<Guitar> guitarList = new List<Guitar>();
        public HomeController(IGuitarRepository _guitars)
        {
            guitars = _guitars;
        }
        public IActionResult Main()
        {
            return View(guitars.GetGuitars());
        }
        [HttpPost]
        public async void AddItemInBaskent()
        {
            string name = "";
            var json = HttpContext.Request.Body;
            using (StreamReader reader = new StreamReader(json))
            {
                name = await reader.ReadToEndAsync();
                name = name.Trim('\"');
            }
            guitarList.Add(guitars.GetGuitarByName(name));
        }
    }
}
