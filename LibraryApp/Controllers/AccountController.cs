using System.Security.Cryptography;
using System.Text;
using LibraryApp.Data;
using LibraryApp.DTOs;
using LibraryApp.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{

    public class AccountController : BaseApiController
    {
        //Data context is taken from DbContext.cs
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        
        //Probably need to create two of these determining each role: one for librarian and one for Visitor
        [HttpPost("register")] //Post: api/Account/register
        public async Task<ActionResult<User>> Register(RegisterDto registerDto)
        {
            if (await UserExists(RegisterDto.Username)) return BadRequest("username is taken");
            
            //Specified the keyword using here because specifying the using keyword deletes the class after usage. This is garbage collection.
            using var hmac = new HMACSHA512(); //hmacsha512 gives the salt key.

            var user = new User
            {
                username = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password), 
                    PasswordSalt = hmac.Key
            };

            _context.User.add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        
        //Checking if the username/user has already registered
        private async Task<bool> UserExists(string username)
        {
            //The following line returns true if if there is a matching username
            return await _context.User.AnyAsync(User => User.UserName.ToLower() == username.ToLower())
        }
    }

}