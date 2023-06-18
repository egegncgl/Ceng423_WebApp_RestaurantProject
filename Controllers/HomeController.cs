using Ceng423_WebApp_RestaurantProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Ceng423_WebApp_RestaurantProject.Controllers
{
    public class HomeController : Controller
    {
        private List<string> cartItems; // This represents the cart items. You may use a different data structure or storage mechanism.

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            cartItems = new List<string>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Restaurants()
        {
            return View();
        }
        public IActionResult Chart()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddToCart(string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                cartItems.Add(item);
            }

            // You can optionally redirect to the Chart action to display the updated cart
            return RedirectToAction("Chart");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}