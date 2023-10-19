//This controller controls logging a user in

using LibraryApp.Data;
using LibraryApp.DTOs;
using LibraryApp.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers;

public class LoginController : BaseApiController
{
    private readonly DataContext _context;

    public LoginController(DataContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AppUser>> Login(LoginDto loginDto)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);
        if (user == null) return Unauthorized("invalid username");
        return user;
    }

}