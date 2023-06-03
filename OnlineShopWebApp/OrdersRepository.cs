using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public class OrdersRepository : IOrdersRepository
	{
		private List<Cart> orders = new List<Cart>();

		public void Add(Cart cart)
		{
			orders.Add(cart);
		}

	}
}
