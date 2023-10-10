using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace LibraryApp.Entities
{
    public class LibraryBook
    {
        //These define the properties
        [Key]
        public string Isbn { get; set; }

        [Required]
        public string Title { get; private set; }
        [Required]
        public string Author { get; private set; }
        [Required]
        public string Genre { get; private set; }
        
        public bool Available { get; set; }
        
        //Constructor to populate the object on creation

        public LibraryBook()
        {
            Available = true;
        }
        
        public LibraryBook(string iSbn, string title, string author, string genre)
        {
            Isbn = iSbn;
            Title = title;
            Author = author;
            Genre = genre;
            Available = true;
        }

    }
}
