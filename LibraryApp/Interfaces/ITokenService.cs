using LibraryApp.Entities.Users;

namespace LibraryApp.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
