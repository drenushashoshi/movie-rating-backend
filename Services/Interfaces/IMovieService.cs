using movie_rating_backend.Models.DTOs.MovieDtos;

namespace movie_rating_backend.Services.Interfaces
{
    public interface IMovieService
    {
        Task<GetMovieDto> GetMovieByTitle(string title);

        Task<GetMovieDto> CreateMovie(CreateMovieDto newMovie);
        Task<List<GetMovieDto>> GetAllMovies();

        Task<double> GetAverageRating(Guid movieId);

        Task<List<GetMovieDto>> SearchMovies(string query);
    }
}
