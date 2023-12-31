﻿using Microsoft.EntityFrameworkCore;
namespace Ceng423_WebApp_RestaurantProject.Models

{
    [Keyless]
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }

     
        public User(string username, string password, string email, string firstName, string lastName, bool isAdmin = false)
        {
            Username = username;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            IsAdmin = isAdmin;
        }

        
        public bool ValidateLogin(string username, string password)
        {
            return (Username == username && Password == password);
        }

 
        public void UpdateProfile(string email, string firstName, string lastName)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }

}
