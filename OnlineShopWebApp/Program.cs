using OnlineShopWebApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IProductsRepository, ProductsRepository>();
builder.Services.AddSingleton<ICartsRepository, CartsRepository>();
builder.Services.AddSingleton<IOrdersRepository, OrdersRepository>();
builder.Services.AddSingleton<IRolesRepository, RolesRepository>();
builder.Services.AddControllersWithViews();

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

app.Run();
