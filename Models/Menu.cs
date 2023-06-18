using Microsoft.EntityFrameworkCore;

namespace Ceng423_WebApp_RestaurantProject.Models
{
    [Keyless]
    public class Menu
    {
        public int RestaurantID { get; set; }

        public int MenuID { get; set; }
         public String Food { get; set; }
        public int Price { get; set; }


        //functions

        //Constroctors
        public Menu() { }
        public Menu(int restaurantID, int menuID, String food, int price)
        {
            RestaurantID = restaurantID;
            MenuID = menuID;
            Food = food;
            Price = price;
            
        }
        /*
        //Menüye yemek ve fiyatını ekliyor
        public void AddItem(string itemName, double price)
        {
            Items.Add(itemName, price);
        }
        //menüden item kaldırıyor
        public void RemoveItem(string itemName)
        {
            Items.Remove(itemName);
        }
        //menüdeki yemeğin fiyatını dönüyor
        public double GetPrice(string itemName)
        {
            if (Items.ContainsKey(itemName))
                return Items[itemName];

            return 0.0; // Eğer yemek ismi mevcut değilse 0.0 değerini döndürür
        }
        */
    }
}
