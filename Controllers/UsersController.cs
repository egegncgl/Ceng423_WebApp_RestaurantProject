using Microsoft.AspNetCore.Mvc;
using Ceng423_WebApp_RestaurantProject.Models;


namespace Ceng423_WebApp_RestaurantProject.Controllers
{
    public class UsersController : Controller
    {
        private static List<User> users = new List<User>()
        {
            new User{ Username="test1", Password="wasd", Email="test1@gmail.com", FirstName="test1", LastName="test1", IsAdmin=false},
            new User{ Username="test2", Password="1234", Email="test2@gmail.com", FirstName="test2", LastName="test2", IsAdmin=false},
            new User{ Username="test3", Password="qweqwe", Email="test3@gmail.com", FirstName="test3", LastName="test3", IsAdmin=false},
            new User{ Username="test4", Password="1234!*", Email="test4@gmail.com", FirstName="test4", LastName="test4", IsAdmin=true}
        };


        public static List<User> GetUsers() { return users; }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(users);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult AddUsers([FromBody] User user)
        {
            try
            {
                users.Add(user);
                return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] User user)
        {
            try
            {
                User foundedUser = users.SingleOrDefault(u => u.Username == user.Username);
                if (foundedUser != null)
                {
                    foundedUser.Username = user.Username;
                    foundedUser.Password = user.Password;
                    foundedUser.Email = user.Email;
                    foundedUser.FirstName = user.FirstName;
                    foundedUser.LastName = user.LastName;
                    return Ok(foundedUser);
                }
                else
                {
                    return BadRequest("User doesn't found!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public IActionResult DeleteUser(string username)
        {
            try
            {
                User deletedUser = users.SingleOrDefault(u => u.Username == username);
                if (deletedUser != null)
                {
                    users.Remove(deletedUser);
                    return Ok(deletedUser);
                }
                else
                {
                    return BadRequest("User doesn't found!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}