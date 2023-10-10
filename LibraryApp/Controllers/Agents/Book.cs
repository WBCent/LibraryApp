using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace Library
{
    public class libraryBook
    {
        //These define the properties
        [Required] 
        public readonly string ISBN;

        [Required]
        public readonly string Title;
        
        [Required]
        public readonly string Author;
        
        [Required]
        public readonly string Genre;
        
        public bool Available;
        
        //Constructor to populate the object on creation
        public libraryBook(string isbn, string title, string author, string genre)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Genre = genre;
            Available = true;
        }

    }
}
