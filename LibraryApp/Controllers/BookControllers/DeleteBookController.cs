using System.Data;
using LibraryApp.Data;
using LibraryApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers.BookControllers
{
    public class DeleteBookController : BaseApiController
    {
        private readonly DataContext _context;
        public DeleteBookController(DataContext context)
        {
            _context = context;
        }

        [HttpDelete]
        //An action result is a return status code type
        public async Task<ActionResult<bool>> DeleteBook(DeleteDto deleteDto)
        {
            if (await BookExists(deleteDto.ISBN)) return BadRequest("This book does not exist");

            var entity = await _context.Book.FindAsync(deleteDto.ISBN);

            if (entity != null)
            {
                _context.Book.Remove(entity);
                await _context.SaveChangesAsync();
            }

            return Ok(true);
        }
        
        private async Task<bool> BookExists(string isbn)
        {
            return await _context.Book.AnyAsync(x => x.ISBN == isbn);
        }
    }
}

