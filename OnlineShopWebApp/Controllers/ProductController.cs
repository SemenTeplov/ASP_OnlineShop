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
        public string Index(int id)
        {
            var product = productsRepository.TryGetById(id);

            if (product == null)
            {
                return $"Продукта с таким Id={id} не существует";
            }
            return product.Name;
            
        }
    }
}
