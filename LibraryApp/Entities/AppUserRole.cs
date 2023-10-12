using LibraryApp.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace LibraryApp.Entities;

public class AppUserRole : IdentityUserRole<int>
{
    public User Username { get; set; }
    
    public User Role { get; set; }
}