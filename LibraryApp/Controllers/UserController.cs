using LibraryApp.Data;
using LibraryApp.Entities;
using LibraryApp.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers;


[ApiController]
[Authorize] //Cannot have allow anonymous at the top with authorize at points; the one at the top outweighs the ones at the bottom.
//The api/controller thing takes the first part of the controller, in this case Book, and sets that as the route
[Route("api/[controller]")] // /api/user
public class UserController : BaseApiController
{
    //if you use _context instead this.context becomes context
    private readonly DataContext context;

    public UserController(DataContext context)
    {
        this.context = context;
    }

    [HttpGet]
    //A task represents an asynchronous action that returns a value.
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await this.context.User.ToListAsync();

        return users;
    }

    //Only able to do it if they are authorised. Can be placed up top, see up top.
    [Authorize]
    //Here with the HttpGet we introduce a route parameter which will return an individual book
    [HttpGet("{username}")]
    public async Task<ActionResult<User>> GetUser(string username)
    {
        var user = await this.context.User.FindAsync(username);

        return user;
    }
}