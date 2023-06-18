using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUsersManager usersManager;

        public UserController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Users()
        {
            var userAcconts = usersManager.GetAll();

            return View(userAcconts);
        }
        public IActionResult UserAccount(string userName)
        {
            var userAccont = usersManager.TryGetByName(userName);

            return View(userAccont);
        }
        public IActionResult ChangePassword(string userName)
        {
            var changePassword = new ChangePassword()
            {
                UserName = userName
            };

            return View(changePassword);
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            if (ModelState.IsValid)
            {
                usersManager.ChangePassword(changePassword.UserName, changePassword.Password);

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("User", "ChangePassword");
        }
    }
}
