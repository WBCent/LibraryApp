using LibraryApp.Entities;
using LibraryApp.Entities.Users;
using Microsoft.EntityFrameworkCore;

//Namespace is solution name . file name
namespace LibraryApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public required DbSet<LibraryBook> Book { get; set; }
        public required DbSet<User> User { get; set; }

    }
    
}
