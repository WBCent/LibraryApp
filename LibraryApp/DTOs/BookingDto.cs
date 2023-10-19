

using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DTOs
{
    public class BookingDto
    {
        [Key] public string booking_id;
        [Required] public string LibraryRoom_ID;
        [Required] public DateTime startTime;
        [Required] public DateTime endTime;
        
        

    }
}