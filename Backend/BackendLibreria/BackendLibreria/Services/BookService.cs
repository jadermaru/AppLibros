
using BackendLibreria.Data;
using BackendLibreria.DTOs;
using BackendLibreria.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendLibreria.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDBContext _context;

        public BookService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<BookDTO>> GetBooksAsync()
        {
            var books = await _context.Books
                .Include(b => b.Category)
                .OrderBy(b => b.BookId)
                .ToListAsync();

            return books.Select(b => b.BookDTORequest()).ToList();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.BookId == id);
        }

        public async Task<BookDTO?> InsertBookAsync(CreateBookDTO bookDto)
        {
            var existingBook = await _context.Books
                .FirstOrDefaultAsync(b => b.Title.ToLower() == bookDto.Title.ToLower());

            if (existingBook != null)
                return null;

            var book = new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                CategoryId = bookDto.CategoryId,
                Summary = bookDto.Summary,
                Details = bookDto.Details
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            var category = await _context.Categories.FindAsync(book.CategoryId);

            return new BookDTO
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                CategoryId = book.CategoryId,
                Summary = book.Summary,
                Details = book.Details,
                Category = new CategoryDTO
                {
                    CategoryId = category?.CategoryId ?? 0,
                    Name = category?.Name ?? string.Empty
                }
            };
        }


        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
