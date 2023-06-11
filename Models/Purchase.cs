namespace Ceng423_WebApp_RestaurantProject.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int UserID { get; set; }
        public Chart chart { get; set; }
        public string PaymentMethod { get; set; }

        public Purchase(int purchaseID, int userID, Chart chart, string paymentMethod)
        {
            PurchaseID = purchaseID;
            UserID = userID;
            this.chart = chart;
            PaymentMethod = paymentMethod;
        }

        public void AddItem(string itemName, double price)
        {
            chart.AddItem(itemName, price);
        }

        public void RemoveItem(string itemName)
        {
            chart.RemoveItem(itemName);
        }

        public double GetTotalPrice()
        {
            return chart.GetTotalPrice();
        }

        public void PrintPurchase()
        {
            Console.WriteLine("Satın Alma Detayları:");
            Console.WriteLine("Satın Alma ID: " + PurchaseID);
            Console.WriteLine("Kullanıcı ID: " + UserID);
            Console.WriteLine("Ödeme Yöntemi: " + PaymentMethod);
            Console.WriteLine("Satın Alınan Ürünler:");
            foreach (var item in chart.items)
            {
                Console.WriteLine(item.Key + " - $" + item.Value);
            }
            Console.WriteLine("Toplam Fiyat: $" + GetTotalPrice());
        }
    }

}
