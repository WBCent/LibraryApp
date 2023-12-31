

using System.Text;
using LibraryApp.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using LibraryApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Extensions
{
    //By making a class static means we can use the methods without instantiating a new instance of the class
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServicesDb(this IServiceCollection services, IConfiguration config)
        {
            //Adds database
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            
            //Easier to test against interfaces
            return services;
        }
    }
}