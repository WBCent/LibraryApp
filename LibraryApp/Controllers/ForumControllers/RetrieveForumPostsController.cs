using LibraryApp.Data;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers.Forum;

public class RetrieveForumPostsController : BaseApiController
{
    private readonly DataContext _context;

    public RetrieveForumPostsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ForumPost>> RetrieveForumPosts()
    {
        return Ok(entities);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ForumPost>> RetrieveForumPost()
    {
        return Ok(entity);
    }

}