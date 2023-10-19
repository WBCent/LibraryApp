using LibraryApp.Data;
using LibraryApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers.BlogPosts
{
    public class RemoveBlogPostController : BaseApiController
    {
        private readonly DataContext _context;

        public RemoveBlogPostController(DataContext context)
        {
            _context = context;
        }

        [HttpDelete("/Delete")]
        public async Task<ActionResult<bool>> RemoveBlogPost(RemoveBlogPostDto removeBlogPostDto)
        {
            if (await BlogPostExists(removeBlogPostDto.BlogPost_Id)) return BadRequest("This blog post does not exist");

            var entity = await _context.BlogPosts.FindAsync(removeBlogPostDto.BlogPost_Id);

            if (entity != null)
            {
                _context.BlogPosts.Remove(entity);
                await _context.SaveChangesAsync();
            }

            return Ok(true);
        }

        private async Task<bool> BlogPostExists(string blogpostid)
        {
            return await _context.BlogPosts.AnyAsync(x => x.BlogPostId == blogpostid);
        }


    }
}