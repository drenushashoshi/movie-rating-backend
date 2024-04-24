using Microsoft.Extensions.Configuration.UserSecrets;
using movie_rating_backend.Models.DTOs.MovieDtos;
using movie_rating_backend.Models.DTOs.RatingDtos;

namespace movie_rating_backend.Services.Interfaces
{
    public interface IRatingService
    {
        public Task<CreateRatingDto> CreateRatingAsync(CreateRatingDto dto);

        public Task<CreateRatingDto> GetRatingAsync(Guid userID, Guid movieID);

        public Task<List<MovieRatingDto>> GetMoviesRatedByUser(Guid userId);

        public Task<bool> UpdateRatingAsync(Guid movieId,Guid userId,UpdateRatingDto dto);
    }
}
