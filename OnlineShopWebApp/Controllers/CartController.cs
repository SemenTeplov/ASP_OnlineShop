﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;

        public CartController(IProductsRepository productsRepository, ICartsRepository cartsRepository)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
        }
        public IActionResult Index(int id)
        {
            var cart = cartsRepository.TryGetByUserId(Contstants.UserId);

            return View(cart);
            
        }
        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            cartsRepository.Add(product, Contstants.UserId);

            return RedirectToAction("Index");

        }
		public IActionResult DeacreseAmount(int productId)
		{
			cartsRepository.DeacreseAmount(productId, Contstants.UserId);

			return RedirectToAction("Index");

		}
		public IActionResult Clear()
		{
			cartsRepository.Clear(Contstants.UserId);

			return RedirectToAction("Index");

		}
	}
}
