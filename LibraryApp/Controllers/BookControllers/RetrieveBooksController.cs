using LibraryApp.Data;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers.BookControllers
{
    public class RetrieveBooksController : BaseApiController
    {
        private readonly DataContext _context;
        public RetrieveBooksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        //A task represents an asynchronous action that returns a value.
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _context.Book.ToListAsync();
            return Ok(books);
        }
        
        //Here with the HttpGet we introduce a route parameter which will return an individual book
        [HttpGet("{Isbn}")]
        public async Task<ActionResult<Book>> GetBook(string Isbn)
        {
            var book = await _context.Book.FindAsync(Isbn);
            
            return Ok(book);
        }
    }
}

