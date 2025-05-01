using BackendLibreria.DTOs;
using BackendLibreria.Models;

namespace BackendLibreria.Services
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task<BookDTO?> InsertBookAsync(CreateBookDTO bookDto);
        Task<bool> DeleteBookAsync(int id);
    }
}
