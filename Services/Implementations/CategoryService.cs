using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using movie_rating_backend.Entity;
using movie_rating_backend.Models.DTOs.MovieDtos;
using movie_rating_backend.Services.Interfaces;
using movie_rating_backend.Models.DTOs.MovieDtos;

namespace movie_rating_backend.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateCategory(string name)
        {
            var category = new Category { Name = name };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<bool> UpdateCategory(int id, string name)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return false;

            category.Name = name;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GetMovieDto>> GetMoviesByCategory(string categoryName)
        {
            var category = await _context.Categories
                .Include(c => c.Movies)
                .FirstOrDefaultAsync(c => c.Name == categoryName);

            if (category == null)
                return new List<GetMovieDto>();

            var movieDtos = category.Movies
                .Select(movie => new GetMovieDto
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    Year = movie.Year,
                    CoverImageUrl = movie.CoverImageUrl,
                    AvgRating = movie.AvgRating

                })
                .ToList();

            return movieDtos;
        }

    }
}
