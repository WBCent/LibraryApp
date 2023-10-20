using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Entities;

public class LibraryRoomBooking
{
    [ForeignKey("LibraryRoom")] public Guid LibraryRoomId;
    [Key] public Guid BookingId;
    [Required] public string User;
    [Required] public DateTime StartTime;
    [Required] public DateTime EndTime;

    public LibraryRoomBooking(Guid libraryRoomId, string user, DateTime startTime, DateTime endTime)
    {
        LibraryRoomId = libraryRoomId;
        BookingId = new Guid();
        User = user;
        StartTime = startTime;
        EndTime = endTime;
    }
    
}