using LibraryApp.Data;
using LibraryApp.DTOs;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers.BookControllers.BookReviewControllers.cs;

public class AddBookReviewController : BaseApiController
{
    private readonly DataContext _context;

    public AddBookReviewController(DataContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    public async Task<ActionResult<bool>> AddBookReview(BookReviewDto bookReviewDto)
    {
        var entity = new BookReview(bookReviewDto.Rating, bookReviewDto.Review_Body, bookReviewDto.Author,
            bookReviewDto.ISBN);

        await _context.BookReviews.AddAsync(entity);
        await _context.SaveChangesAsync();

        return Ok(true);
    }


}