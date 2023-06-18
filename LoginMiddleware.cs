namespace Ceng423_WebApp_RestaurantProject
{
    using Ceng423_WebApp_RestaurantProject.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Login _login;

        public LoginMiddleware(RequestDelegate next, Login login)
        {
            _next = next;
            _login = login;
        }
        [HttpPost]
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/Home/Login" && context.Request.Method == HttpMethods.Post)
            {
                string username = context.Request.Form["loginUsername"];
                string password = context.Request.Form["loginPassword"];

                
                User user = _login.AuthenticateUser(username, password);

                if (user == null)
                {
                    
                    context.Response.StatusCode = 401; 
                    await context.Response.WriteAsync("Kimlik doğrulama başarısız.");
                }
                else
                {
                    
                    context.Response.Redirect("/Home/Restaurants");
                    
                    await _next(context);
                }
            }
        }
    }
}
