using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.DTOs;

public class BookReviewDto
{
    [Key] public Guid Review_Id;
    [Required] public int Rating;
    [Required] public string Review_Body;
    [Required] public string Author;
    [Required] public string ISBN;

}