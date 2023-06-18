using Ceng423_WebApp_RestaurantProject.Models;

public class LoginMiddleware
{
    private readonly RequestDelegate _next;
    private readonly Login _login;

    public LoginMiddleware(RequestDelegate next, Login login)
    {
        _next = next;
        _login = login;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path == "/Home/Login" && context.Request.Method == HttpMethods.Post)
        {
            // Kullanıcı adı ve şifre bilgilerini alınması gereken yerleri belirtin.
            string username = context.Request.Form["loginUsername"];
            string password = context.Request.Form["loginPassword"];

            // Kimlik doğrulama işlemi
            User user = _login.AuthenticateUser(username, password);

            if (user == null)
            {
                // Kimlik doğrulama başarısız olduğunda buraya gelebilirsiniz.
                context.Response.StatusCode = 401; // Unauthorized
                //await context.Response.WriteAsync("Kimlik doğrulama başarısız.");
            }
            else
            {
                // Kimlik doğrulama başarılı olduğunda buraya gelebilirsiniz.
                // Kimlik doğrulama sonrası isteği işleme devretmek için _next delege'sini çağırın.

                //sayfaya yönlendirme yapılacak bu kısımda
                context.Response.Redirect("/Home/Restaurants");
                return;
            }
            return; // Return ekledim, sonraki InvokeAsync çağrılmaması için.
        }
        await _next(context);
    }
}
