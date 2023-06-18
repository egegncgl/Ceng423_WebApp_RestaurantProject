using Ceng423_WebApp_RestaurantProject.Models;
using Microsoft.EntityFrameworkCore;



public class AppContext:DbContext{
    
    public AppContext(DbContextOptions<AppContext>options):base(options)
    {
 
    }
    public DbSet<Menu> Menus {get;set;}
    public DbSet<Restaurant> Restaurant {get;set;}
    public DbSet<User> Users { get; set; }

    
    
}
