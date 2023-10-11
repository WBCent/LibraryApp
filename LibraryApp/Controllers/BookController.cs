using LibraryApp.Data;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers;


[ApiController]
//The api/controller thing takes the first part of the controller, in this case Book, and sets that as the route
[Route("api/[controller]")] // /api/book
public class BookController : BaseApiController
{
    //if you use _context instead this.context becomes context
    private readonly DataContext context;

    public BookController(DataContext context)
    {
        this.context = context;
    }

    [HttpGet]
    //A task represents an asynchronous action that returns a value.
    public async Task<ActionResult<IEnumerable<LibraryBook>>> GetBooks()
    {
        var books = await this.context.Book.ToListAsync();

        return books;
    }

    //Here with the HttpGet we introduce a route parameter which will return an individual book
    [HttpGet("{Isbn}")]
    public async Task<ActionResult<LibraryBook>> GetBook(string Isbn)
    {
        var book = await this.context.Book.FindAsync(Isbn);

        return book;
    }
}