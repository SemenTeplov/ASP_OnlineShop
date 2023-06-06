using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly IRolesRepository rolesRepository;

        public AdminController(IProductsRepository productsRepository, IOrdersRepository ordersRepository, IRolesRepository rolesRepository)
        {
            this.productsRepository = productsRepository;
            this.ordersRepository = ordersRepository;
            this.rolesRepository = rolesRepository;
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
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Roles()
        {
            var roles = rolesRepository.GetAll();

            return View(roles);
        }
        public IActionResult RemoveRole(string RoleName)
        {
            rolesRepository.Remove(RoleName);

            return RedirectToAction("Roles");
        }
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже есть.");
            }
            if (ModelState.IsValid)
            {
                rolesRepository.Add(role);
                return RedirectToAction("Roles");
            }

            return View(role);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.Add(product);

            return RedirectToAction("Product");
        }

        public IActionResult EditProduct(int productId)
        {
            var product = productsRepository.TryGetById(productId);

            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.Update(product);

            return RedirectToAction("Product");
        }
    }
}
