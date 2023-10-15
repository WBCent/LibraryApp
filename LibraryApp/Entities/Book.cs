using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Entities
{
    public class Book
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Key]
        public string ISBN { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool Available { get; set; }
        public string Borrower { get; set; }
        
        public DateTime Date { get; set; }

        public Book(string title, string author, string isbn, string genre, string description, bool available)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Genre = genre;
            Description = description;
            Available = available;
            Borrower = "";
        }

        public Book()
        {
            
        }

        public void BorrowBook(string borrower)
        {
            Borrower = borrower;
        }

        
    } 
}

