namespace Ceng423_WebApp_RestaurantProject.Services
{
    public class TypeBroker
    {
        private static IResponseFormatter formatter = new TextResponseFormatter();
        public static IResponseFormatter Formatter => formatter;
    }
}
