using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Helper;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;
		private readonly DatabaseContext dbContext_;

		public ProductController(IProductsRepository productsRepository_, DatabaseContext dbContext_)
		{
			this.productsRepository = productsRepository_;
			this.dbContext_ = dbContext_;
		}
		public IActionResult Products()
        {
            var products = productsRepository.GetAll();

            return View(Mapping.ToProductViewModels(products));
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
                Description = product.Description,
				ImagePath = product.ImagePath
			};

            productsRepository.Add(productDb);

            return RedirectToAction("AddProduct");
        }

        public IActionResult EditProduct(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);

            return View(Mapping.ToProductViewModel(product));
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
                Description = product.Description,
				ImagePath = product.ImagePath
			};

            productsRepository.Update(productDb);

            return RedirectPermanent("../Order/Orders");
        }

        [HttpGet]
		public IActionResult RemoveProduct(Guid productId)
		{
			var product = productsRepository.TryGetById(productId);
  
			return View(Mapping.ToProductViewModel(product));
		}

		[HttpPost, ActionName("RemoveProduct")]
		public async Task<IActionResult> RemoveProduct(ProductViewModel product)
		{
            var productDb = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Coast = product.Coast,
                Description = product.Description,
                ImagePath = product.ImagePath
            };

			//productsRepository.Remove(productDb);
			dbContext_.Products.Remove(productDb);
			dbContext_.SaveChangesAsync();
			return RedirectPermanent("../Order/Orders");
		}
	}
}
