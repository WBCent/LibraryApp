using LibraryApp.Data;
using LibraryApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers.ForumControllers;

public class EditForumPostController : BaseApiController
{

    private readonly DataContext _context;

    public EditForumPostController(DataContext context)
    {
        _context = context;
    }

    [HttpPut]
    public async Task<ActionResult<bool>> EditForumPost(EditForumPostDto editForumPostDto)
    {
        var entity = await _context.ForumPosts.FindAsync(editForumPostDto.id);

        if (entity != null)
        {
            entity.Title = editForumPostDto.Title;
            entity.Body = editForumPostDto.Body;
        }
        else
        {
            return BadRequest("There is no Forum Post with this name");
        }

        return Ok(true);
    } 


}