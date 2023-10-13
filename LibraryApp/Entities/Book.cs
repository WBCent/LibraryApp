using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Entities
{
    public class Book
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
        public string Borrower;

        public Book(string title, string author, string isbn, string genre, string description, bool available)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Genre = genre;
            Description = description;
            Available = available;
        }

        public void BorrowBook(string borrower)
        {
            Borrower = borrower;
        }

        
    } 
}

