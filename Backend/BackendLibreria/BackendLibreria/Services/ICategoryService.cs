using BackendLibreria.DTOs;
using BackendLibreria.Models;

namespace BackendLibreria.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<Category?> InsertCategoryAsync(CategoryDTO categoryDto);
    }
}
