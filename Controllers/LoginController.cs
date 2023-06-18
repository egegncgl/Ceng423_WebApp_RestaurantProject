using Ceng423_WebApp_RestaurantProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ceng423_WebApp_RestaurantProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly Login _login;

        public LoginController(Login login)
        {
            _login = login;
        }

        [HttpPost]
        public IActionResult Authenticate(string username, string password)
        {
            User user = _login.AuthenticateUser(username, password);

            if (user != null)
            {
                // Kimlik doğrulama başarılı olduğunda Restaurants sayfasına yönlendir.
                return RedirectToAction("Restaurants", "Home");
            }
            else
            {
                // Kimlik doğrulama başarısız olduğunda aynı sayfada kal ve hata mesajını göster.
                ViewBag.ErrorMessage = "Kimlik doğrulama başarısız.";
                return View();
            }
        }
    }
}
