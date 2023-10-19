using LibraryApp.Data;
using LibraryApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers.Forum;

public class LikePostController : BaseApiController
{
    private readonly DataContext _context;

    public LikePostController(DataContext context)
    {
        _context = context;
    }

    [HttpPut]
    public async Task<ActionResult<int>> LikePost(Like_DislikePostDto likeDislikePostDto)
    {
        var entity = await _context.ForumPost.FindAsync(likeDislikePostDto.id);

        if (entity != null)
        {
            entity.Likes++;
            await _context.ForumPost.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        else
        {
            return BadRequest("There is no blog post with this id");
        }

        return Ok(entity.Likes);
    }


}