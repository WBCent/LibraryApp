//This controller controls signing up a user to the system
using LibraryApp.Data;
using LibraryApp.DTOs;
using LibraryApp.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers;

public class RegisterController: BaseApiController
{
    //This is to do with the database
    private readonly DataContext _context;
    //This is important for creating the user
    private readonly UserManager<AppUser> _userManager;
    
    public RegisterController(DataContext context, UserManager<AppUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
    {
        
        if (await UserExists(registerDto.Username)) return BadRequest("username is taken");

        var user = new AppUser()
        {
            UserName = registerDto.Username,
        };

        await _userManager.AddToRoleAsync(user, registerDto.role);
        
        return user;

    }
    
    private async Task<bool> UserExists(string username)
    {
        //The following line returns true if if there is a matching username
        return await _context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
    }
    
}