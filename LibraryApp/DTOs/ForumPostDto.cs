using System.ComponentModel.DataAnnotations;

namespace LibraryApp.DTOs
{
    public class ForumPostDto
    {
        [Required] public string Title;
        [Required] public string Body;
        [Required] public string Author;   
    }
}