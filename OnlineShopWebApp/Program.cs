using OnlineShopWebApp;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
                  .Enrich.FromLogContext()
                  .Enrich.WithProperty("ApplicationName", "Online Shop"));

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

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
