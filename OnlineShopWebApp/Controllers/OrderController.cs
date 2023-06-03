using Microsoft.AspNetCore.Mvc;

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
		public IActionResult Buy()
		{
			var excistingCart = cartsRepository.TryGetByUserId(Contstants.UserId);
			ordersRepository.Add(excistingCart);
			cartsRepository.Clear(Contstants.UserId);

			return View();
		}
	}
}
