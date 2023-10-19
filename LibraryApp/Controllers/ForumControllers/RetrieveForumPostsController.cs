using LibraryApp.Data;
using LibraryApp.DTOs;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers.ForumControllers;

public class RetrieveForumPostsController : BaseApiController
{
    private readonly DataContext _context;

    public RetrieveForumPostsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<ForumPost>>> RetrieveForumPosts()
    {
        var entities = await _context.ForumPosts.ToListAsync();
        return Ok(entities);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ForumPost>> RetrieveForumPost(SingleForumPostDto singleForumPostDto)
    {
        var entity = await _context.ForumPosts.FindAsync(singleForumPostDto.id);
        return Ok(entity);
    }

}