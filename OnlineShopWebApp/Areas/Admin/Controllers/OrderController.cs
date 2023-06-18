using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrdersRepository ordersRepository;

        public OrderController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Orders()
        {
            var orders = ordersRepository.GetAll();

            return View(orders);
        }
        public IActionResult OrderDetails(Guid OrderIdId)
        {
            var order = ordersRepository.TryGetById(OrderIdId);

            return View(order);
        }
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            ordersRepository.UpdateStatus(orderId, status);

            return RedirectToAction("Orders");
        }
    }
}
