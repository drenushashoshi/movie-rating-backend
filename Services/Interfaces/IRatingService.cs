using Microsoft.Extensions.Configuration.UserSecrets;
using movie_rating_backend.Models.DTOs.RatingDtos;

namespace movie_rating_backend.Services.Interfaces
{
    public interface IRatingService
    {
        public Task<CreateRatingDto> CreateRatingAsync(CreateRatingDto dto);

        public Task<CreateRatingDto> GetRatingAsync(Guid userID, Guid movieID);
    }
}
