using LibraryApp.Data;
using LibraryApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers.Forum;

public class DislikePostController : BaseApiController
{
    private readonly DataContext _context;

    public DislikePostController(DataContext context)
    {
        _context = context;
    }

    [HttpPut("/addLike")]
    public async Task<ActionResult<int>> DislikePost(DislikePostDto dislikePostDto)
    {

        var entity = await _context.ForumPost.FindAsync(dislikePostDto.id);
        if (entity != null)
        {
            entity.Dislikes++;
            await _context.ForumPost.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        else
        {
            return BadRequest("The Post was not found");
        }

        return Ok(entity.Dislikes);
    }

    private async Task<bool> FindPost(Guid id)
    {
        return await _context.ForumPost.AnyAsync(id);
    }
}