using BackendLibreria.DTOs;
using BackendLibreria.Models;
using BackendLibreria.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendLibreria.Controllers
{
    [Route("api/Book/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            return await _bookService.GetBooksAsync();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
                return NotFound();

            return book;
        }

        [Authorize]
        [HttpPost("InsertBook")]
        public async Task<ActionResult<BookDTO>> InsertBookAsync(CreateBookDTO bookDto)
        {
            var newBook = await _bookService.InsertBookAsync(bookDto);
            if (newBook == null)
                return BadRequest("A book with the same title already exists.");

            return CreatedAtAction(nameof(GetBook), new { id = newBook.BookId }, newBook);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
