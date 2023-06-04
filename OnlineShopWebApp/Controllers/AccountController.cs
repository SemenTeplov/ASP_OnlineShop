using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registr()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registr(Registr registr)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
