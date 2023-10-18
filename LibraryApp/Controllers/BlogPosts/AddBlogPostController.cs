using LibraryApp.Controllers.BookControllers;
using LibraryApp.Data;
using LibraryApp.DTOs;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers.BlogPosts;

public class AddBlogPostController : BaseApiController
{
    private readonly DataContext _context;

    public AddBlogPostController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<BlogPost>> AddBlogPost(BlogPostDto blogPostDto)
    {
        var blogPost = new BlogPost(blogPostDto.BlogPostId, blogPostDto.Title, blogPostDto.Body,
            blogPostDto.PublishDate, blogPostDto.Author);
        await _context.BlogPosts.AddAsync(blogPost);
        await _context.SaveChangesAsync();
        return Ok();

    } 
    


}