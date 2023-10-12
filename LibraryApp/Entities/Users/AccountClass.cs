
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LibraryApp.Entities.Users
{
    public class User : IdentityUser<int>
    {
        //ICollection is a type of List, they are interchangeable
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}