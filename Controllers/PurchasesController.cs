using Microsoft.AspNetCore.Mvc;
using Ceng423_WebApp_RestaurantProject.Models;

namespace Ceng423_WebApp_RestaurantProject.Controllers
{
    public class PurchasesController : Controller
    {
        private static readonly List<Purchase> purchases = new List<Purchase>();


        [HttpGet]
        public IActionResult GetAllPurchases()
        {
            try
            {
                return Ok(purchases);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        public IActionResult AddPurchase([FromBody] Purchase purchase)
        {
            try
            {
                List<User> allUsers = UsersController.GetUsers();
                User orderedUser = allUsers.FirstOrDefault(u => u.Username.Equals(purchase.Username));
                if (orderedUser != null) {
                    ChartsController.AddChart(purchase.Chart);
                    purchases.Add(purchase);
                    return Ok("Purchase is added");
                }
                else
                {
                    return BadRequest("User not found!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult RemovePurchase([FromBody] RemovePurchaseDTO removePurchaseDTO)
        {
            try
            {
                bool isRemoved = ChartsController.RemoveChart(removePurchaseDTO.Username, removePurchaseDTO.Item);
                if (isRemoved)
                {
                    return Ok("Remove item in Purchase");
                }
                else
                {
                    return BadRequest("There is a error!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult GetTotalPrice()
        {
            try
            {
                double totalPrice = 0.0;
                foreach (var purchase in purchases)
                {
                    foreach (var item in purchase.Chart.Items)
                    {
                        totalPrice += item.Value;
                    }
                }
                return Ok(totalPrice);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult GetTotalPriceByUsername(string username)
        {
            try
            {
                double totalPrice = 0.0;

                bool isUsernameFound = false;

                foreach (var purchase in purchases)
                {
                    if (purchase.Username.Equals(username))
                    {
                        foreach (var item in purchase.Chart.Items)
                        {
                            totalPrice += item.Value;
                        }
                        isUsernameFound = true;
                    }
                }

                if (isUsernameFound)
                {
                    return Ok(totalPrice);
                }
                else
                {
                    return BadRequest("Username is not found!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        public IActionResult DeleteOrder(string username, string item)
        {
            bool removed = ChartsController.RemoveChart(username, item);
            if (removed)
            {
                return Ok("Item removed from chart.");
            }
            else
            { 
                return NotFound("Item not found in chart.");
            }
        }

    }
}
