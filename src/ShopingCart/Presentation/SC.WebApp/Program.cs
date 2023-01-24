using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using SC.Business.DataServices;
using SC.Business.Interfaces;
using SC.Data;

namespace SC.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //configure entity framework
            builder.Services.AddDbContext<StoreManagementDbContext>(
                options => options.UseSqlServer("Data Source=DESKTOP-RSNV8UD; Database=ShopingCartDb;TrustServerCertificate=True;Integrated Security=SSPI;"));

            // all of the custom configuration
            builder.Services.AddScoped<IProductServices , ProductServices>();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}