using BackendLibreria.Models;

namespace BackendLibreria.DTOs
{
    public static class BookRequest
    {
        public static BookDTO BookDTORequest(this Book book)
        {
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
                    CategoryId = book.Category?.CategoryId ?? 0,
                    Name = book.Category?.Name
                }
            };
        }
    }
}
