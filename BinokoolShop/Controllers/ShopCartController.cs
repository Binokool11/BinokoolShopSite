﻿using BinokoolShop.Models;
using BinokoolShop.Models.Entity;
using BinokoolShop.Models.Repository.InterfaceRepository;
using BinokoolShop.Models.Session;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BinokoolShop.Views.ShopCart
{
    public class ShopCartController : Controller
    {
        private readonly IGuitarRepository guitars;
        private readonly Shop shop;
        public ShopCartController(IGuitarRepository _guitars, Shop _shop)
        {
            guitars=_guitars;
            shop = _shop;
        }

        public IActionResult Index()
        {
            var shopCartItems = shop.GetShopCartItems();
            shop.ShopCartItems = shopCartItems;

            var model = new ShopCartIndexViewModel
            {
                shopCart = shop
            };

            return View(model);
        }

        public IActionResult AddToCart(int itemId)
        {
            var currentGuitar = guitars.GetGuitars().FirstOrDefault(c => c.ItemId == itemId);
            if (currentGuitar != null)
            {
                shop.AddToCart(currentGuitar, 1);
            }
            return RedirectToAction("Index");
        }




        #region Нормальный код с использование сессии(не получилось)
        //public IActionResult AddToCart(int itemId)
        //{
        //    Guitar currentGuitar = guitars.GetGuitars().FirstOrDefault(guitar => guitar.itemId == itemId);
        //    if (currentGuitar != null)
        //    {
        //        GetCart(currentGuitar, 1);
        //    }
        //    return RedirectToActionPermanent("Index", new ShopCartIndexViewModel { cart = GetCart() });
        //}

        //public Cart GetCart(Guitar guitar = null, int value = 0)
        //{
        //    var session = HttpContext.Session;
        //    Cart? cart = UserSessionExtensions.Get<Cart>(session,"Cart");
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        cart.AddItem(guitar,value);
        //        UserSessionExtensions.Set(session, cart,"Cart");
        //    }
        //    return cart;
        //}

        //public IActionResult Index(ShopCartIndexViewModel model)
        //{
        //    return View(model);
        //}
        #endregion
    }
}
