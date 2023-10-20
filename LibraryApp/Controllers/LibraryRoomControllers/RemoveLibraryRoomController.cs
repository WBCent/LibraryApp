using LibraryApp.Data;
using LibraryApp.DTOs;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers.LibraryRoomControllers;

public class RemoveLibraryRoomController
{
    private readonly DataContext _context;

    public RemoveLibraryRoomController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<string>> BookLibraryRoom(EditLibraryRoomBookingDto editLibraryRoomBookingDto)
    {
        var entity = await _context.LibraryRoomBookings.FindAsync(editLibraryRoomBookingDto.LibraryRoomBookingID);

        entity.StartTime = editLibraryRoomBookingDto.StartTime;
        entity.EndTime = editLibraryRoomBookingDto.EndTime;

        await _context.LibraryRoomBookings.AddAsync(entity);
        await _context.SaveChangesAsync();

        return Ok("Created");
    }
}