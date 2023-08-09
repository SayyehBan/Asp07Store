using Asp07Store.ShopUI.Models;
using Asp07Store.ShopUI.Models.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var cnnString = builder.Configuration.GetConnectionString("StoreCnn");
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(cnnString));
builder.Services.AddScoped<IProduct, ProductRepository>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<Basket>(c => SessionBasket.GetBasket(c));
builder.Services.AddScoped<IOrders, OrdersRepository>();
builder.Services.AddScoped<ICategory, CategoryRepository>();
var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("pagination", "/{controller=home}/{action=index}/{category}/Page{PageNumber}");
    endpoints.MapControllerRoute("pagination", "/{controller=home}/{action=index}/Page{PageNumber}");
    endpoints.MapControllerRoute("pagination", "/{controller=home}/{action=index}/{category}");
    endpoints.MapDefaultControllerRoute();
});


app.Run();
