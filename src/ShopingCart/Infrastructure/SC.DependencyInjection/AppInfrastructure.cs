using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SC.Business.DataServices;
using SC.Business.Interfaces;
using SC.Data;
using SC.Data.Interfaces;

namespace SC.DependencyInjection
{
    public static class AppInfrastructure
    {
        public static void AppDISetup(this IServiceCollection services, IConfiguration configuration)
        {
            //configure entity framework
            services.AddDbContext<StoreManagementDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

            //repository configuration
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie((cookieOptions) => 
                {
                    cookieOptions.LoginPath = "/Authentication/login";
                    cookieOptions.Cookie = new CookieBuilder { Name = "ShopingCartCookie" };
                });
            // all of the custom configuration
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IStoreServices, StoreServices>();

            //automapper Configuration
            services.AddAutoMapper(typeof(BusinessEntityMappings));
        }
    }
}