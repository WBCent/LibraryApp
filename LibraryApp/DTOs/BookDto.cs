using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DTOs
{
    public class BookDto
    {
        [Required]
        public string Title { get; init; }
        [Required]
        public string Author { get; init; }
        [Key]
        public string ISBN { get; init; }
        [Required]
        public string Genre { get; init; }
        [Required]
        public string Description { get; init; }
        [Required]
        public bool Available { get; init; }

        public DateTime Date;
        
        
        
    }
}