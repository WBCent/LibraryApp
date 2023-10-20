using LibraryApp.Data;
using LibraryApp.DTOs;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers.LibraryRoomControllers;

public class BookLibraryRoomController : BaseApiController
{
    private readonly DataContext _context;

    public BookLibraryRoomController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<bool>> BookLibraryRoom(BookLibraryRoomDto bookLibraryRoomDto)
    {
        var entity = new LibraryRoomBooking(bookLibraryRoomDto.LibraryRoomId, bookLibraryRoomDto.user,
            bookLibraryRoomDto.startTime, bookLibraryRoomDto.endTime);
        await _context.LibraryRoomBookings.AddAsync(entity);
        await _context.SaveChangesAsync();

        return Ok("Created");
    }

}