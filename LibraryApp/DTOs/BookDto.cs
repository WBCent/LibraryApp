using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DTOs
{
    public class BookDto
    {
        [Required]
        public string Title;
        [Required]
        public string Author;
        [Key]
        public string ISBN;
        [Required]
        public string Genre;
        [Required]
        public string Description;
        [Required]
        public bool Available;

        public DateTime Date;
    }
}