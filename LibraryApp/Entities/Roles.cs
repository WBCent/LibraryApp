using Microsoft.AspNetCore.Identity;

namespace LibraryApp.Entities;

public class Roles : IdentityRole<int>
{
    public ICollection<AppUserRole>
}