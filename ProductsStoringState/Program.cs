using Microsoft.EntityFrameworkCore;
using ProductsStoringState.BusinessLayer.Service;
using ProductsStoringState.DataLayer;
using ProductsStoringState.DataLayer.Repository;

namespace ProductsStoringState
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddMemoryCache();
            string connectionString = builder.Configuration.GetConnectionString("ProductConnection");
            builder.Services.AddDbContext<ProductsContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
