using BinokoolShop.Models.Entity;
using BinokoolShop.Models.Repository.InterfaceRepository;
using BinokoolShop.ViewModel;
using BinokoolShop.Views.ShopCart;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace BinokoolShop.Controllers
{
    public class OrderingController : Controller
    {
        private readonly ICategoryRepository categories;
        private readonly IGuitarRepository guitars;
        private readonly IUserRepository userRepository;
        private readonly ShopRepository shop;
        private readonly Validation validation;
        public OrderingController(ICategoryRepository _categories, IGuitarRepository _guitars, IUserRepository _userRepository, ShopRepository _shop, Validation _validation)
        {
            categories = _categories;
            guitars = _guitars;
            userRepository = _userRepository;
            shop = _shop;
            validation = _validation;
        }

        public IActionResult Ordering()
        {
            ShopCartIndexViewModel model = new ShopCartIndexViewModel { ShopCart = shop, Validation = validation };
            return View(model);
        }
        public IActionResult ShowError()
        {
            return View(validation);
        }
        public IActionResult CompliteOrder(User user)
        {
            
            if (ModelState.IsValid)
            {
                if (user.Name.Length < 3 || user.Name.Length > 15)
                {
                    ModelState.AddModelError("Name", "Длинна имени пользователя должно быть больше 3 и не больше 15 ");
                }
                if (!Regex.IsMatch(user.Phone, validation.patternPhone))
                {
                    ModelState.AddModelError("Phone", "Не корректно введен номер телефона");
                }
                if (!Regex.IsMatch(user.Email, validation.patternEmail))
                {
                    ModelState.AddModelError("Email", "Не корректно введен email");
                }
                if (ModelState.IsValid)
                {
                    userRepository.SetUser(user, shop.GetShopCartItems());
                    validation.ShowError = false;
                    return View();
                }
                else
                {
                    validation.modelError = ModelState;
                    validation.ShowError = true;
                    return RedirectToAction("Ordering");
                }
            }
            else
            {
                validation.ShowError = true;
                validation.modelError = ModelState;
                return RedirectToAction("Ordering");
            }
            
        }
    }
}
