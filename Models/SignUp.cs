using Microsoft.EntityFrameworkCore;

namespace Ceng423_WebApp_RestaurantProject.Models
{  [Keyless]
    public class SignUp
    {

        public List<User> users;

        public SignUp()
        {
            users = new List<User>();
        }

        public void RegisterUser(string username, string password, string email, string firstName, string lastName)
        {
            // Kullanıcı adının benzersiz olup olmadığını kontrol etmek için gerekli mantığı ekleyebilirsiniz.
            // Burada örnek olarak kontrol yapmaksızın kullanıcıları doğrudan ekliyoruz.

            User newUser = new User(username, password, email, firstName, lastName);
            users.Add(newUser);
            Console.WriteLine("Kullanıcı kaydedildi.");
        }
    }
}
