using Ceng423_WebApp_RestaurantProject.Models;
using Ceng423_WebApp_RestaurantProject.Services;
using System.Text;

namespace Ceng423_WebApp_RestaurantProject
{
    public class RestaurantEndpoint
    {
        private IResponseFormatter formatter;
        private List<Restaurant> restaurants;

        public RestaurantEndpoint(IResponseFormatter responseFormatter, List<Restaurant> restaurantList)
        {
            formatter = responseFormatter;
            restaurants = restaurantList;
        }

        public async Task Endpoint(HttpContext context)
        {
            string response = GenerateRestaurantListResponse();
            await formatter.Format(context, response);
        }

        private string GenerateRestaurantListResponse()
        {
            // Restoran listesinden restoranları alarak bir yanıt oluştur
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Restaurant List:");
            foreach (var restaurant in restaurants)
            {
                sb.AppendLine("Name: " + restaurant.restaurantName);
                sb.AppendLine("Description: " + restaurant.restaurantDescription);
                sb.AppendLine("Rate: " + restaurant.restaurantRate);
                sb.AppendLine("Phone: " + restaurant.Phone);
                sb.AppendLine("------------------");
            }
            return sb.ToString();
        }
    }
}
