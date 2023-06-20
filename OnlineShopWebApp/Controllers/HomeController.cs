using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using OnlineShop.Db;
using OnlineShopWebApp.Helper;
using OnlineShopWebApp.Models;
using System.Diagnostics;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;

        public HomeController(IProductsRepository productsRepository, ICartsRepository cartsRepository)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
        }
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(Contstants.UserId);
            var products = productsRepository.GetAll();

            return View(Mapping.ToProductViewModels(products));
        }
    }
}