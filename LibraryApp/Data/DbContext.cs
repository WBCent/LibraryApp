using LibraryApp.Entities;
using LibraryApp.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

//Namespace is solution name . file name
namespace LibraryApp.Data
{
    public class DataContext : IdentityDbContext<User, userR, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public required DbSet<LibraryBook> Book { get; set; }
        public required DbSet<User> User { get; set; }

        
    }
    
}
