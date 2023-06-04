using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
	public class OrderController : Controller
	{
		private readonly ICartsRepository cartsRepository;
		private readonly IOrdersRepository ordersRepository;

		public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository)
		{
			this.cartsRepository = cartsRepository;
			this.ordersRepository = ordersRepository;
		}

		public IActionResult Index()
		{ 
			return View();
		}

		[HttpPost]
		public IActionResult Buy(UserDeliveryInfo user)
		{
			var excistingCart = cartsRepository.TryGetByUserId(Contstants.UserId);
			var order = new Order()
			{
				User = user,
				Items = excistingCart.Items
            };
			ordersRepository.Add(order);
			cartsRepository.Clear(Contstants.UserId);

			return View();
		}
	}
}
