using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersManager usersManager;

        public AccountController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login", "Account");
            }

            var userAccount = usersManager.TryGetByName(login.UserName);

            if (userAccount == null)
            {
                ModelState.AddModelError("", "Такого пользователя не существует.");
            }
            if (userAccount.Password != login.Password)
            {
                ModelState.AddModelError("", "Пароль не правильный.");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registr()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registr(Registr registr)
        {
            if (registr.UserName == registr.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            if (ModelState.IsValid)
            {
                usersManager.Add(new UserAccount
                {
                    UserName = registr.UserName,
                    Password = registr.Password,
                    Phone = registr.Phone
                });

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Registr", "Account");
        }
    }
}
