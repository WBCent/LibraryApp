using LibraryApp.Data;
using LibraryApp.DTOs;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers.BookControllers;

public class BorrowBookController : BaseApiController
{
    private readonly DataContext _context;
    public BorrowBookController(DataContext context)
    {
        _context = context;
    }

    [HttpPut("borrow")]
    public async Task<ActionResult> BorrowBook(BorrowDto borrowDto)
    {
        //Retrieve entity by id
        var entity = await _context.Book.FirstOrDefaultAsync(book => book.ISBN == borrowDto.ISBN);
        
        //update entity field and save changes to the database.
        if (entity != null)
        {
            entity.Borrower = borrowDto.Borrower;
            entity.Date = borrowDto.Date.AddDays(3);
            await _context.SaveChangesAsync();
            return Ok(entity.Date);
        }
        else
        {
            return BadRequest("This book does not exist or there is an error with the system");
        }
    }
    
    
}