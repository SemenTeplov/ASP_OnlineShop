using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class ProductsRepository
    {
        private static List<Product> products = new List<Product>() 
        { 
            new Product("Product1", 10, "Desc1", "#"),
            new Product("Product2", 20, "Desc2", "#"),
            new Product("Product3", 30, "Desc3", "#"),
            new Product("Product4", 40, "Desc4", "#"),
            new Product("Product5", 10, "Desc5", "#"),
            new Product("Product6", 20, "Desc6", "#"),
            new Product("Product7", 40, "Desc7", "#"),
            new Product("Product8", 30, "Desc8", "#"),
        };

        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }
    }
}
