using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DTOs
{
    public class LoginDto
    {
        [Key]
        public string Username;
        [Required]
        public string Password;
    }
    
}

