using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductsRepository productsRepository;

        public CartController()
        {
            productsRepository = new ProductsRepository();
        }
        public IActionResult Index(int id)
        {
            var cart = CartsRepository.TryGetByUserId(Contstants.UserId);

            return View(cart);
            
        }
        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            CartsRepository.Add(product, Contstants.UserId);

            return RedirectToAction("Index");

        }
    }
}
