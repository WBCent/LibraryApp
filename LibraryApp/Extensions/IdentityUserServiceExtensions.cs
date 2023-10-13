using LibraryApp.Data;
using LibraryApp.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace LibraryApp.Extensions;

public static class IdentityUserServiceExtensions
{
    public static IServiceCollection AddApplicationServicesIdentity(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddIdentity<AppUser, AppRole>() //This line is adding the identity services to the applications services collection.
            .AddRoles<Librarian>()
            .AddRoles<Visitor>()
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders(); 
        
        return services;
    }
}