using movie_rating_backend.Models.DTOs;

namespace movie_rating_backend.Services
{
    public interface IMovieService
    {
        Task<GetMovieDto> GetMovieByTitle(string title);

        Task<GetMovieDto> CreateMovie(CreateMovieDto newMovie);
        Task<List<GetMovieDto>> GetAllMovies();
    }
}
