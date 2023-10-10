using LibraryApp.Entities;
using Microsoft.EntityFrameworkCore;

//Namespace is solution name . file name
namespace LibraryApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<LibraryBook> Book { get; set; }
        
    }
    
}
