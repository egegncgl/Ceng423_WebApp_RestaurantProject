namespace Ceng423_WebApp_RestaurantProject.Models
{
    public class Login
    {
        public List<User> users;

        public Login(List<User> users)
        {
            this.users = users;
        }

        public User AuthenticateUser(string username, string password)
        {
            //burası database e göre değişecek
            User user = users.FirstOrDefault(u => u.ValidateLogin(username, password));
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
