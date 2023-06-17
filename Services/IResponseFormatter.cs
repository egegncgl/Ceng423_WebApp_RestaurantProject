namespace Ceng423_WebApp_RestaurantProject.Services
{
    public interface IResponseFormatter
    {
        Task Format(HttpContext context, string data);
    }
}
