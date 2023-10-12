using System.Security.Cryptography;
using System.Text;
using LibraryApp.Data;
using LibraryApp.DTOs;
using LibraryApp.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using LibraryApp.Entities.Users;
using LibraryApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers
{

    public class AccountController : BaseApiController
    {
        //Data context is taken from DbContext.cs
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        
        //Probably need to create two of these determining each role: one for librarian and one for Visitor
        [HttpPost("register")] //Post: api/Account/register
        
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            RegisterDto newUser = new RegisterDto();
            //if user already exists return username is taken
            if (await UserExists(newUser.Username)) return BadRequest("username is taken");
            
            //Specified the keyword using here because specifying the using keyword deletes the class after usage. This is garbage collection.
            using var hmac = new HMACSHA512(); //hmacsha512 gives the salt key.

            //Below an object initialiser is used instead of a constructor. An initialiser populates the object after it has been constructed but before anything else has happened to it, whereas a constructor does it at construction.
            var user = new User()
            {
                username = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)), 
                PasswordSalt = hmac.Key
            };

            //_context here is referring to an instance of DbContext (I think)
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return new UserDto
            {
                Username = user.username,
                Token = _tokenService.CreateToken(user)
            };
        }


        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(LoginDto loginDto)
        {
            //Get null if not found in the database. Cannot use AnyAsync here as you need to know the public key to use it.
            var user = await _context.User.SingleOrDefaultAsync(x => x.username == loginDto.Username);
            if (user == null) return Unauthorized("invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (var i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("invalid password");
            }
            return user;
        }
        
        
        
        //Checking if the username/user has already registered
        private async Task<bool> UserExists(string username)
        {
            //The following line returns true if if there is a matching username
            return await _context.User.AnyAsync(x => x.username.ToLower() == username.ToLower());
        }
    }

}