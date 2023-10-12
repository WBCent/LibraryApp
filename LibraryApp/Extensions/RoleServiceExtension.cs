using LibraryApp.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace LibraryApp.Extensions;

public static class RoleServiceExtension
{
    public static IServiceCollection AddRoleServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<Visitor>()
            .AddRoles<Librarian>();
        
        return services;
    }
}