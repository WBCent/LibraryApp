// What is a DTO? A DTO is a data container for moving data between layers. They are also termed as transfer objects. DTO is only used to pass data and does nto contain any business logic. They only have simple getters and setters.

using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
    
}
