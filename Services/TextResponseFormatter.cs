namespace Ceng423_WebApp_RestaurantProject.Services
{
    public class TextResponseFormatter : IResponseFormatter
    {
        private int responseCounter = 0;
        private static TextResponseFormatter? shared;
        public async Task Format(HttpContext context, string data)
        {
            responseCounter++;
            await context.Response.WriteAsync($"Response {responseCounter++}:\n{data}");
        }
        public static TextResponseFormatter Singeleton
        {
            get
            {
                if (shared == null)
                {
                    shared = new TextResponseFormatter();
                }
                return shared;
            }
        }
    }
}
