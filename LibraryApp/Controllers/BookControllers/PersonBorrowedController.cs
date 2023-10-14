using LibraryApp.Data;
using LibraryApp.DTOs;
using LibraryApp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers.BookControllers
{
    public class PersonBorrowedController : BaseApiController
    {
        private readonly DataContext _context;

        public PersonBorrowedController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Librarian")]
        public async Task<List<Book>> PersonBorrowed(PersonBorrowedDto personBorrowedDto)
        {
            List<Book> books = await _context.Book.Where(b => b.Borrower == personBorrowedDto.Id).ToListAsync();
            return books;
        }
    }
}

