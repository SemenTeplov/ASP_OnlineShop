using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using OnlineShop.Db;
using OnlineShopWebApp.Models;

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
        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Coast = product.Coast,
                Description = product.Description,
                ImagePath = product.ImagePath
            };

            cartsRepository.Add(productViewModel, Contstants.UserId);

            return RedirectToAction("Index");

        }
		public IActionResult DeacreseAmount(Guid productId)
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
