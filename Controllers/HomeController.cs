using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Ceng423_WebApp_RestaurantProject.Models;

namespace Ceng423_WebApp_RestaurantProject.Controllers
{
    public class HomeController : Controller
    {
        private List<string> cartItems; 
        private readonly ILogger<HomeController> _logger;
        private readonly AppContext _appContext;

        public HomeController(ILogger<HomeController> logger, AppContext appContext)
        {
            _logger = logger;
            cartItems = new List<string>();
            _appContext = appContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(String loginUsername, String loginPassword)
        {
            var userFromDb = _appContext.User.FirstOrDefault(m => m.Username == loginUsername && m.Password == loginPassword);
            if (userFromDb == null)
            {
                ViewBag.LoginStatus = 0;
                return View();
            }

            return RedirectToAction("Restaurants");
        }

        public IActionResult Restaurants()
        {
            var restaurants = _appContext.Restaurant.ToList();
            return View(restaurants);
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
