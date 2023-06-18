using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Products()
        {
            var products = productsRepository.GetAll();

            var productsViewModels = new List<ProductViewModel>();

            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Coast = product.Coast,
                    Description = product.Description,
                    ImagePath = product.ImagePath
                };
                productsViewModels.Add(productViewModel);
            }

            return View(productsViewModels);
        }
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var productDb = new Product
            {
                Name = product.Name,
                Coast = product.Coast,
                Description = product.Description
            };

            productsRepository.Add(productDb);

            return RedirectToAction("Product");
        }

        public IActionResult EditProduct(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);

            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var productDb = new Product
            {
                Name = product.Name,
                Coast = product.Coast,
                Description = product.Description
            };

            productsRepository.Update(productDb);

            return RedirectToAction("Product");
        }
    }
}
