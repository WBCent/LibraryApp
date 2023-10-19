using LibraryApp.Data;
using LibraryApp.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers.Forum;

public class DeleteForumPostController : BaseApiController
{
    private readonly DataContext _context;

    public DeleteForumPostController(DataContext context)
    {
        _context = context;
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteForumPost(DeleteForumPostDto deleteForumPostDto)
    {
        if (await ForumPostExists(deleteForumPostDto.ForumPostGuid)) return BadRequest("Forum Post was not found");

        
        
        
        return Ok("The Forum Post was Deleted");
    }

    private async Task<bool> ForumPostExists(Guid id)
    {
        return await _context.ForumPost.AnyAsync(x => x.ForumPost_ID == id);
    }
}