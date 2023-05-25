using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsRepository productsRepository;

        public ProductController()
        {
            productsRepository = new ProductsRepository();
        }
        public IActionResult Index(int id)
        {
            var product = productsRepository.TryGetById(id);

            return View(product);
            
        }
    }
}
