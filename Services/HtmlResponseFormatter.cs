namespace Ceng423_WebApp_RestaurantProject.Services
{
    namespace Assignment2.Services
    {
        public class HtmlResponseFormatter : IResponseFormatter
        {
            public async Task Format(HttpContext context, string data)
            {
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync($@"
                <!DOCTYPE html>
                <html lang=""en"">
                <head><title>Ege-Response</title></head>
                <body>
                    <div> 
                        <h3>
                            Formatted Response
                        </h3>
                        <span>
                            {data}
                        </span>
                    </div>
                </body>
                </html>
            ");
            }
        }
    }

}
