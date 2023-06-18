using Microsoft.EntityFrameworkCore;

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

        // Constructor
        public User(string username, string password, string email, string firstName, string lastName, bool isAdmin = false)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.IsAdmin = isAdmin;
        }

        // Method to validate login credentials
        public bool ValidateLogin(string username, string password)
        {
            return (Username == username && Password == password);
        }

        // Method to update user profile information
        public void UpdateProfile(string email, string firstName, string lastName)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }

}
