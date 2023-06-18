using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICartsRepository
    {
        void Add(ProductViewModel product, string userId);
		void Clear(string userId);
		void DeacreseAmount(Guid productId, string userId);
		Cart TryGetByUserId(string userId);
    }
}