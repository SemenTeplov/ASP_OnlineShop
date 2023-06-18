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

        public List<Order> GetAll()
        {
			return orders;
        }

        public Order TryGetById(Guid orderId)
        {
            return orders.FirstOrDefault(x => x.Id == orderId);
        }

        public void UpdateStatus(Guid orderId, OrderStatus status)
        {
            var order = TryGetById(orderId);

            if (order != null)
            {
                order.orderStatus = status;
            }
        }
    }
}
