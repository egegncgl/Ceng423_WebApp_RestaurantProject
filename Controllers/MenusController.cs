using Microsoft.AspNetCore.Mvc;
using Ceng423_WebApp_RestaurantProject.Models;

namespace Ceng423_WebApp_RestaurantProject.Controllers
{
    public class MenusController : Controller
    {
        private static List<Menu> menus = new List<Menu>()
        {
            new Menu
            {
              MenuID = 1,
              RestaurantID = 1,
              Items = new Dictionary<string, double>
              {
                 { "Item 1", 10 },
                 { "Item 2", 5 },
                 { "Item 3", 8 }
              }
            },
            new Menu
            {
              MenuID = 2,
              RestaurantID = 2,
              Items = new Dictionary<string, double>
              {
                 { "Item 1", 20 },
                 { "Item 2", 45 },
                 { "Item 3", 58 }
              }
            },
            new Menu
            {
               MenuID = 3,
              RestaurantID = 3,
              Items = new Dictionary<string, double>
              {
                 { "Item 1", 16 },
                 { "Item 2", 32 },
                 { "Item 3", 46 }
              }
            },
            new Menu
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
        };

        [HttpGet]
        public IActionResult GetAllMenus()
        {
            return Ok(menus);
        }

        [HttpPost]
        public IActionResult AddMenus([FromBody] Menu menu)
        {
            try
            {
                menus.Add(menu);
                return Ok(menus);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public IActionResult UpdateMenus([FromBody] Menu menu)
        {
            try
            {
                Menu foundedMenu = menus.SingleOrDefault(m => m.MenuID == menu.MenuID);


                if (foundedMenu != null)
                {
                    foundedMenu.MenuID = menu.MenuID;
                    foundedMenu.RestaurantID= menu.RestaurantID;
                    foundedMenu.Items= menu.Items;
                    return Ok(foundedMenu);
                }
                else
                {
                    return BadRequest("Menu doesn't found!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete]
        public IActionResult DeleteMenus(int id)
        {
            Menu deleteMenu = menus.SingleOrDefault(m => m.MenuID== id);
            if (deleteMenu != null)
            {
                menus.Remove(deleteMenu);
                return Ok(deleteMenu);
            }
            else
            {

                return NotFound();
            }
        }

    }
}
