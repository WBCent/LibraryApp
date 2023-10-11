using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LibraryApp.Entities.Users;
using LibraryApp.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace LibraryApp.Services;

public class TokenService : ITokenService
{
    public string CreateToken(User user)
    {

        private readonly SymmetricSecurityKey _key;
        
        public TokenService(IConfiguration config)
        {
            //Takes a byte array so we need to encode our config
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]))
        }


        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.username);
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    
    
    }
}