using LibraryApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers.BlogPosts
{
    public class RemoveBlogPostController : BaseApiController
    {
        private readonly DataContext _context;

        public RemoveBlogPostController(DataContext context)
        {
            _context = context;
        }
        
        [HttpDelete("{blogPostId}")]
        public Task<Void> RemoveBlogPost()




    }
}