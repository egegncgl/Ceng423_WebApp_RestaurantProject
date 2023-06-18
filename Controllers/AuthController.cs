using Ceng423_WebApp_RestaurantProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ceng423_WebApp_RestaurantProject.Controllers
{
    public class AuthController : Controller
    {

        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                return Ok(UsersController.GetUsers());

            }
            catch (System.Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            try
            {
                List<User> allUsers = UsersController.GetUsers();
                User currentUser = allUsers.FirstOrDefault(u => u.Username.Equals(userLogin.Username) && u.Password.Equals(userLogin.Password));
                if (currentUser == null)
                {
                    return BadRequest("Wrong username or password!");
                }

                return Ok(currentUser);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        public IActionResult Register([FromBody] User userRegister)
        {
            try
            {
                List<User> allUsers = UsersController.GetUsers();
                if (allUsers == null)
                {
                    return BadRequest("There are not users!");
                }
                else
                {
                    if (ValidateRegister(userRegister.Username))
                    {
                        return BadRequest("There is a user with the same username!");
                    }
                    else
                    {
                        userRegister.IsAdmin = false;
                        allUsers.Add(userRegister);
                        return Ok(userRegister);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ValidateRegister(string username)
        {
            List<User> users = UsersController.GetUsers();
            User user = users.FirstOrDefault(u => u.Username.Equals(username));
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}