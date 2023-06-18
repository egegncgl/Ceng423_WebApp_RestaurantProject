using Microsoft.EntityFrameworkCore;

namespace Ceng423_WebApp_RestaurantProject.Models
{
    [Keyless]
    public class Login
    {
        private AppContext db;
        public List<User> users;

        public Login(AppContext dbContext)
        {
            db = dbContext;
           
        }

        public User AuthenticateUser(string username, string password)
        {
            //burası database e göre değişecek
             User user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                Console.WriteLine("Giriş başarılı. Hoş geldiniz, " + user.Username + "!");
                return user;
            }
            else
            {
                Console.WriteLine("Giriş başarısız. Kullanıcı adı veya şifre hatalı.");
                return null;
            }
        }
    }
}
