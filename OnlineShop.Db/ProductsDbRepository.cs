﻿using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DatabaseContext dbContext_;

        public ProductsDbRepository(DatabaseContext dbContext)
        {
            dbContext_ = dbContext;
        }

        /*private List<Product> products = new List<Product>()
        {
            new Product("Product1", 10, "Desc1", "https://mobimg.b-cdn.net/v3/fetch/fd/fd6d44593e0493f5fec6a8bfdd197be2.jpeg"),
            new Product("Product2", 20, "Desc2", "https://mobimg.b-cdn.net/v3/fetch/fd/fd6d44593e0493f5fec6a8bfdd197be2.jpeg"),
            new Product("Product3", 30, "Desc3", "https://mobimg.b-cdn.net/v3/fetch/fd/fd6d44593e0493f5fec6a8bfdd197be2.jpeg"),
            new Product("Product4", 40, "Desc4", "https://mobimg.b-cdn.net/v3/fetch/fd/fd6d44593e0493f5fec6a8bfdd197be2.jpeg"),
            new Product("Product5", 10, "Desc5", "https://mobimg.b-cdn.net/v3/fetch/fd/fd6d44593e0493f5fec6a8bfdd197be2.jpeg"),
            new Product("Product6", 20, "Desc6", "https://mobimg.b-cdn.net/v3/fetch/fd/fd6d44593e0493f5fec6a8bfdd197be2.jpeg"),
            new Product("Product7", 40, "Desc7", "https://mobimg.b-cdn.net/v3/fetch/fd/fd6d44593e0493f5fec6a8bfdd197be2.jpeg"),
            new Product("Product8", 30, "Desc8", "https://mobimg.b-cdn.net/v3/fetch/fd/fd6d44593e0493f5fec6a8bfdd197be2.jpeg"),
        };*/

        public void Add(Product product)
        {
            dbContext_.Products.Add(product);
            dbContext_.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return dbContext_.Products.ToList();
        }

        public Product TryGetById(Guid id)
        {
            var product = dbContext_.Products.FirstOrDefault(product => product.Id == id);

			return product;
        }

        public void Update(Product product)
        {
            var existingProduct = dbContext_.Products.FirstOrDefault(x => x.Id == product.Id);

            if (existingProduct == null) { return; }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Coast = product.Coast;
			existingProduct.ImagePath = product.ImagePath;

			dbContext_.SaveChanges();
        }

        /*public void Remove(Product product)
        {
            dbContext_.Products.Remove(product);
            dbContext_.SaveChangesAsync();
        }*/
    }
}
