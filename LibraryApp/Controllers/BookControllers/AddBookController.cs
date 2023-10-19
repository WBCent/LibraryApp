using LibraryApp.Data;
using LibraryApp.DTOs;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers.BookControllers
{
    public class AddBookController : BaseApiController
    {
        private readonly DataContext _context;

        public AddBookController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("AddBook")]
        public async Task<ActionResult<Book>> AddBook(BookDto bookDto)
        {
            if (await BookExists(bookDto.ISBN)) return Conflict("Book is already in the database");
            var book = new Book(bookDto.Title, bookDto.Author, bookDto.ISBN, bookDto.Genre, bookDto.Description,
                bookDto.Available);
            await _context.Book.AddAsync(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBook), new { id = book.ISBN }, book);
        }
    
        public async Task<ActionResult<Book>> GetBook(string id)
        {
            var book = await _context.Book.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    
        private async Task<bool> BookExists(string isbn)
        {
            return await _context.Book.AnyAsync(x => x.ISBN == isbn);
        }
    }
}