using LibraryApp.Data;
using LibraryApp.DTOs;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers.ForumControllers;

public class AddForumPostController : BaseApiController
{
    private readonly DataContext _context;

    public AddForumPostController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<bool>> AddForumPost(ForumPostDto forumPostDto)
    {
        var entity = new ForumPost(forumPostDto.Title, forumPostDto.Body, forumPostDto.Author);

        await _context.ForumPosts.AddAsync(entity);
        await _context.SaveChangesAsync();

        return Ok(true);
    }
    

}