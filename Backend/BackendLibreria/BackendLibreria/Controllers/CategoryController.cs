using BackendLibreria.DTOs;
using BackendLibreria.Models;
using BackendLibreria.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendLibreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _categoryService.GetCategoriesAsync();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryId(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound();

            return category;
        }

        [Authorize]
        [HttpPost("InsertCategory")]
        public async Task<ActionResult<Category>> InsertCategory(CategoryDTO categoryDto)
        {
            var category = await _categoryService.InsertCategoryAsync(categoryDto);
            if (category == null)
                return BadRequest("Category with the same name already exists.");

            return CreatedAtAction(nameof(GetCategoryId), new { id = category.CategoryId }, category);
        }
    }
}
