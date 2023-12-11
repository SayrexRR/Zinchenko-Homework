using BindingModelMvc.BusinessLayer.Services;
using BindingModelMvc.DataLayer.Data;
using BindingModelMvc.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BindingModelMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            string connectionString = builder.Configuration.GetConnectionString("MvcUserContext");
            builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

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
                pattern: "{controller=Users}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
