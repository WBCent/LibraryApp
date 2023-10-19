using LibraryApp.Data;
using LibraryApp.DTOs;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers.LibraryRoomControllers;

public class AddLibraryRoomController : BaseApiController
{
    private readonly DataContext _context;

    public AddLibraryRoomController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<LibraryRoom>> AddLibraryRoom(AddLibraryRoomDto addLibraryRoomDto)
    {
        var libraryRoom = new LibraryRoom(addLibraryRoomDto.Library, addLibraryRoomDto.Name, addLibraryRoomDto.Capacity);

        await _context.LibraryRooms.AddAsync(libraryRoom);
        await _context.SaveChangesAsync();

        return Ok(true);
    }


}