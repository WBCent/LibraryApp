using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Entities
{
    public class LibraryRoom
    {
        [Key] public string LibraryRoom_ID;
        [Required] public string name;
        [Required] public string capacity;
        
    }
}