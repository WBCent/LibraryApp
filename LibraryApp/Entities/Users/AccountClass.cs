
namespace LibraryApp.Entities.Users
{
    public class User
    {
        protected internal string user_id;
        protected internal string username;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        protected internal string role;
    }
}