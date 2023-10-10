using LibraryApp.Data;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers;

[ApiController]
//The api/controller thing takes the first part of the controller, in this case Book, and sets that as the route
[Route("api/[controller]")] // /api/book
public class BookController : ControllerBase
{
    //if you use _context instead this.context becomes context
    private readonly DataContext context;

    public BookController(DataContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<LibraryBook>> GetBooks()
    {
        var books = this.context.Book.ToList();

        return books;
    }

    //Here with the HttpGet we introduce a route parameter which will return an individual book
    [HttpGet("{Isbn}")]
    public ActionResult<LibraryBook> GetBook(string Isbn)
    {
        var book = this.context.Book.Find(Isbn);

        return book;
    }


}