using LibraryApp.Entities;
using LibraryApp.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

//Namespace is solution name . file name
namespace LibraryApp.Data
{
    //Guid is best as it is never repeatable, whereas string, ints etc may be.
    public class DataContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public required DbSet<AppUser> User { get; set; }
        public required DbSet<Book> Book { get; set; }
        
        public required DbSet<BlogPost> BlogPosts { get; set; }
        public required DbSet<ForumPost> ForumPost { get; set; }
    };
}
