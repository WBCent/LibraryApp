
using LibraryApp.Data;
using LibraryApp.DTOs;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers.BlogPosts
{
    public class RetrieveBlogPostController : BaseApiController
    {
        private readonly DataContext _context;

        public RetrieveBlogPostController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetBlogPosts()
        {
            var blogPosts = await _context.BlogPosts.ToListAsync();
            return Ok(blogPosts);
        }

        [HttpGet("{blogPostId}")]
        public async Task<ActionResult<BlogPost>> GetBlogPost(string blogPostId)
        {
            var blogPost = await _context.BlogPosts.FindAsync(blogPostId);
            return Ok(blogPost);
        }

    }
}