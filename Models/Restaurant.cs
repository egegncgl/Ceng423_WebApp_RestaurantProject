namespace Ceng423_WebApp_RestaurantProject.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public String restaurantName { get; set; }

        public string restaurantDescription { get; set; }

        public int restaurantScores { get; set; }

        public int restaurantVoteCounter { get; set; }

        public float restaurantRate { get; set; }

        public Menu menu { get; set; }

        public Restaurant() { }
        public Restaurant(int id, String name, String description, int totalScores, int voteCounter, Menu menu)
        {
            //menüyü dbden okuyabiliriz şimdiik böyle bırakalım 
            this.Id = id;
            this.restaurantName = name;
            this.restaurantDescription = description;
            this.restaurantScores = totalScores;
            this.menu = menu;
            this.restaurantVoteCounter = voteCounter;
            this.restaurantRate = totalScores / voteCounter;
        }
    }


}
