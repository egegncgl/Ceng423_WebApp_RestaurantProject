using Ceng423_WebApp_RestaurantProject.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

// List<User> bileþenini ekleyelim
builder.Services.AddSingleton<List<User>>();

builder.Services.AddSingleton<Login>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Home}/{action=Login}");

app.MapControllerRoute(
    name: "Restaurants",
    pattern: "{controller=Home}/{action=Restaurants}");

app.MapControllerRoute(
    name: "Chart",
    pattern: "{controller=Home}/{action=Chart}");

app.UseMiddleware<LoginMiddleware>();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync($"\n Status Code:{context.Response.StatusCode}");
    await next();
});

app.Run();
