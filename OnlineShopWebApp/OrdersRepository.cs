using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public class OrdersRepository : IOrdersRepository
	{
		private List<Order> orders = new List<Order>();

		public void Add(Order order)
		{
			orders.Add(order);
		}

	}
}
