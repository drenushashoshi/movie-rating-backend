using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movie_rating_backend.Entity;
using movie_rating_backend.Services.Interfaces;

namespace movie_rating_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(string name)
        {
            var category = await _categoryService.CreateCategory(name);
            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, string name)
        {
            var result = await _categoryService.UpdateCategory(id, name);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategory(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("{categoryName}/movies")]
        public async Task<ActionResult<List<Movie>>> GetMoviesByCategory(string categoryName)
        {
            var movies = await _categoryService.GetMoviesByCategory(categoryName);
            return Ok(movies);
        }
    }
}
