

using System.Text;
using LibraryApp.Data;
using LibraryApp.Interfaces;
using LibraryApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using LibraryApp.Data;

namespace LibraryApp.Extensions
{
    //By making a class static means we can use the methods without instantiating a new instance of the class
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            //Adds database
            Services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            //Easier to test against interfaces
            Services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}