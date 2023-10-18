using System.ComponentModel.DataAnnotations;

//Creating a blogpost entity so that the database can hold blogposts on the librarys websites, and blogposts can be added/enjoyed/deleted;

namespace LibraryApp.Entities;

public class BlogPost
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

    public BlogPost(string blogPostId, string title, string body, DateTime publishDate, string author)
    {
        BlogPostId = blogPostId;
        Title = title;
        Body = body;
        PublishDate = publishDate;
        Author = author;
        Likes = 0;
        Dislikes = 0;
        Shares = 0;
    }
}