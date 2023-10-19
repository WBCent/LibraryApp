using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Entities;

public class BookReview
{
    [Key] public Guid Review_Id;
    [Required] public int Rating;
    [Required] public string Review_Body;
    [Required] public string Author;
    [ForeignKey("ISBN")] public string ISBN;

    public BookReview(int rating, string reviewBody, string author, string isbn)
    {
        Review_Id = new Guid();
        Rating = rating;
        Review_Body = reviewBody;
        Author = author;
        ISBN = isbn;
    }
}