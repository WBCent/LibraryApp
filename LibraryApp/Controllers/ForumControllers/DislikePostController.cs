using LibraryApp.Data;
using LibraryApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers.ForumControllers;

public class DislikePostController : BaseApiController
{
    private readonly DataContext _context;

    public DislikePostController(DataContext context)
    {
        _context = context;
    }

    [HttpPut("/addDislike")]
    public async Task<ActionResult<int>> DislikePost(Like_DislikePostDto likeDislikePostDto)
    {
        if (await FindPost(likeDislikePostDto.id)) return BadRequest("There is no post with this ID");

        var entity = await _context.ForumPosts.FindAsync(likeDislikePostDto.id);
        if (entity != null)
        {
            entity.Dislikes++;
            await _context.ForumPosts.AddAsync(entity);
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
        return await _context.ForumPosts.AnyAsync(id);
    }
}