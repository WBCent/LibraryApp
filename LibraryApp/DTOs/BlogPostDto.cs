using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DTOs;

public class BlogPostDto
{
    [Key]
    public string BlogPostId;
    [Required]
    public string Title;
    [Required]
    public string Body;
    [Required]
    public DateTime PublishDate;
    [Required]
    public string Author;
    [Required]
    public int Likes;
    [Required]
    public int Dislikes;
    [Required]
    public int Shares;
}