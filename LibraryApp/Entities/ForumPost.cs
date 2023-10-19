using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Entities;

public class ForumPost
{
    [Key]
    public Guid ForumPost_ID { get; set; }

    [Required] public string Title;
    [Required] public string Body;
    [Required] public DateTime Time;
    [Required] public int Likes;
    [Required] public int Dislikes;
    [Required] public string Author;
    [Required] public int Shares;

    public ForumPost(string title, string body, string author)
    {
        ForumPost_ID = Guid.NewGuid();
        Title = title;
        Body = body;
        Time = new DateTime();
        Likes = 1;
        Dislikes = 0;
        Author = author;
        Shares = 0;
    }
}