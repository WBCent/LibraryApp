using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LibraryApp.Entities.Users;

public class AppUser : IdentityUser<Guid>
{

}