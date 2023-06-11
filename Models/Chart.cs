namespace Ceng423_WebApp_RestaurantProject.Models
{
    public class Chart
    {
        public User user;
        public Dictionary<string, double> items;

        public Chart(User user)
        {
            this.user = user;
            items = new Dictionary<string, double>();
        }

        public void AddItem(string itemName, double price)
        {
            items.Add(itemName, price);
        }

        public void RemoveItem(string itemName)
        {
            items.Remove(itemName);
        }

        public double GetTotalPrice()
        {
            double totalPrice = 0.0;
            foreach (var item in items)
            {
                totalPrice += item.Value;
            }
            return totalPrice;
        }

        public void PrintChart()
        {
            Console.WriteLine("Alışveriş Chartı:");
            foreach (var item in items)
            {
                Console.WriteLine(item.Key + " - $" + item.Value);
            }
            Console.WriteLine("Toplam Fiyat: $" + GetTotalPrice());
        }
    }
}
