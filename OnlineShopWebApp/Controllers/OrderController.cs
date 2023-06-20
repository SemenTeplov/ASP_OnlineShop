using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShop.Db;
using OnlineShopWebApp.Helper;

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
			if(!ModelState.IsValid)
			{
				return View("Index", user);
			}
			var excistingCart = cartsRepository.TryGetByUserId(Contstants.UserId);
			var excistingCartViewModel = Mapping.ToCartViewModel(excistingCart);
			var order = new Order()
			{
				User = user,
				Items = excistingCartViewModel.Items
            };
			ordersRepository.Add(order);
			cartsRepository.Clear(Contstants.UserId);

			return View();
		}
	}
}
