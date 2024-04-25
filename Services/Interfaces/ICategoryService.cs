using System.Collections.Generic;
using System.Threading.Tasks;
using movie_rating_backend.Entity;
using movie_rating_backend.Models.DTOs.MovieDtos;

namespace movie_rating_backend.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> CreateCategory(string name);
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<bool> UpdateCategory(int id, string name);
        Task<bool> DeleteCategory(int id);
        Task<List<GetMovieDto>> GetMoviesByCategory(string categoryName);
    }
}
