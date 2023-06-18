namespace Ceng423_WebApp_RestaurantProject.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Chart Chart { get; set; }
        public string PaymentMethod { get; set; }
       
    }

}
