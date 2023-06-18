using Microsoft.AspNetCore.Mvc;
using Ceng423_WebApp_RestaurantProject.Models;


namespace Ceng423_WebApp_RestaurantProject.Controllers
{
    public class RestaurantsController : Controller
    {
        private static List<Restaurant> restaurants = new List<Restaurant>() {
        new Restaurant { 
            Id = 1, 
            restaurantName = "deneme", 
            restaurantDescription = "asdasd", 
            restaurantScores = 5, 
            restaurantVoteCounter = 2, 
            restaurantRate = 3.45f, 
            Phone = "11111111", 
            menu = new Menu
            {
              MenuID = 1,
              RestaurantID = 1,
              Items = new Dictionary<string, double>
              {
                 { "Item 1", 10 },
                 { "Item 2", 5 },
                 { "Item 3", 8 }
              }
            } },
        new Restaurant { 
            Id = 2, 
            restaurantName = "deneme2", 
            restaurantDescription = "cg", 
            restaurantScores = 3, 
            restaurantVoteCounter = 3, 
            restaurantRate = 1.45f, 
            Phone = "212222",
            menu = new Menu
            {
              MenuID = 2,
              RestaurantID = 2,
              Items = new Dictionary<string, double>
              {
                 { "Item 1", 20 },
                 { "Item 2", 45 },
                 { "Item 3", 58 }
              }
            }
        },
        new Restaurant { 
            Id = 3, 
            restaurantName = "deneme3",
            restaurantDescription = "dg",
            restaurantScores = 2,
            restaurantVoteCounter = 4,
            restaurantRate = 2.45f,
            Phone = "1232132",
            menu = new Menu
            {
              MenuID = 3,
              RestaurantID = 3,
              Items = new Dictionary<string, double>
              {
                 { "Item 1", 16 },
                 { "Item 2", 32 },
                 { "Item 3", 46 }
              }
            }
        },
        new Restaurant { 
            Id = 4,
            restaurantName = "deneme4",
            restaurantDescription = "xx",
            restaurantScores = 4,
            restaurantVoteCounter = 5,
            restaurantRate = 4.45f,
            Phone = "1234352",
            menu = new Menu
            {
              MenuID = 4,
              RestaurantID = 4,
              Items = new Dictionary<string, double>
              {
                 { "Item 1", 12 },
                 { "Item 2", 43 },
                 { "Item 3", 24 }
              }
            }
        }
        };
    

        [HttpGet]
        public IActionResult GetAllRestaurants()
        {
            return Ok(restaurants);
        }

        [HttpPost]
        public IActionResult AddRestaurant([FromBody] Restaurant restaurant)
        {
            try
            {
                restaurants.Add(restaurant);
                return Ok(restaurants);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public IActionResult UpdateRestaurant([FromBody] Restaurant restaurant)
        {
            try
            {
                Restaurant foundedRestaurant = restaurants.SingleOrDefault(r => r.Id == restaurant.Id);
               
                
                if (foundedRestaurant != null)
                {
                    foundedRestaurant.Id = restaurant.Id;
                    foundedRestaurant.restaurantName = restaurant.restaurantName;
                    foundedRestaurant.restaurantDescription = restaurant.restaurantDescription;
                    foundedRestaurant.restaurantRate = restaurant.restaurantRate;
                    foundedRestaurant.restaurantScores = restaurant.restaurantScores;
                    foundedRestaurant.restaurantVoteCounter = restaurant.restaurantVoteCounter;
                    foundedRestaurant.Phone = restaurant.Phone;
                    foundedRestaurant.menu = restaurant.menu;
                    return Ok(foundedRestaurant);
                }
                else
                {
                    return BadRequest("Restaurant doesn't found!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        public IActionResult DeleteRestaurant(int id)
        {
            Restaurant deleteRestaurant = restaurants.SingleOrDefault(r => r.Id == id);
            if (deleteRestaurant != null)
            {
                restaurants.Remove(deleteRestaurant);
                return Ok(deleteRestaurant);
            }
            else
            {

                return NotFound();
            }
        }
    }
}
