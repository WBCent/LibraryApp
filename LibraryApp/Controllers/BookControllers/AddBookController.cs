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
            if (await BookExists(bookDto.ISBN)) return BadRequest("Book is already in the database");

            var book = new Book(bookDto.Title, bookDto.Author, bookDto.ISBN, bookDto.Genre, bookDto.Description,
                bookDto.Available);

            return book;

        }
        private async Task<bool> BookExists(string isbn)
        {
            return await _context.Book.AnyAsync(x => x.ISBN == isbn);
        }
    }
}