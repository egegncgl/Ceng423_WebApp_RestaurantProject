//using Ceng423_WebApp_RestaurantProject.Models;
//using System.Text;
//namespace Ceng423_WebApp_RestaurantProject.Services;

//public class RestaurantMenuEndpoint
//{
//    private IResponseFormatter formatter;
//    private Menu menu;

//    public RestaurantMenuEndpoint(IResponseFormatter responseFormatter, Menu restaurantMenu)
//    {
//        formatter = responseFormatter;
//        menu = restaurantMenu;
//    }

//    public async Task Endpoint(HttpContext context)
//    {
//        string response = GenerateMenuResponse();
//        await formatter.Format(context, response);
//    }

//    private string GenerateMenuResponse()
//    {
//        
//        StringBuilder sb = new StringBuilder();
//        sb.AppendLine("Restaurant Menu:");
//        foreach (var item in menu.Items)
//        {
//            sb.AppendLine(item.Key + " - $" + item.Value);
//        }
//        return sb.ToString();
//    }
//}