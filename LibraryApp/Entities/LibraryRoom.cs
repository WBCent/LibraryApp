using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Entities
{
    public class LibraryRoom
    {
        [Key] public Guid LibraryRoom_ID;
        [Required] public string Library;
        [Required] public string Name;
        [Required] public int Capacity;

        public LibraryRoom(string library, string name, int capacity)
        {
            LibraryRoom_ID = new Guid();
            Library = library;
            Name = name;
            Capacity = capacity;

        }
    }
}