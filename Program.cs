using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppContext>(
    options=>options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "Login",
    pattern: "{controller=Home}/{action=Login}");

app.MapControllerRoute(
    name: "Restaurants",
    pattern: "{controller=Home}/{action=Restaurants}");

app.MapControllerRoute(
    name: "Chart",
    pattern: "{controller=Home}/{action=Chart}");

app.Run();
