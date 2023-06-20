namespace OnlineShopWebApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryInfo User { get; set; }
        public List<CartItemViewModel> Items { get; set; }
        public OrderStatus orderStatus { get; set; }
        public DateTime CreateDateTime { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
            orderStatus = OrderStatus.Created;
            CreateDateTime = DateTime.Now;
        }

        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }
    }
}
