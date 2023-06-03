using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICartsRepository
    {
        void Add(Product product, string userId);
		void Clear(string userId);
		void DeacreseAmount(int productId, string userId);
		Cart TryGetByUserId(string userId);
    }
}