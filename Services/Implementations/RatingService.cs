using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using movie_rating_backend.Entity;
using movie_rating_backend.Models.DTOs.RatingDtos;
using movie_rating_backend.Services.Interfaces;



namespace movie_rating_backend.Services.Implementations
{
    public class RatingService : IRatingService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public RatingService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<CreateRatingDto> CreateRatingAsync(CreateRatingDto ratingDto)
        {
            var newRating = _mapper.Map<Rating>(ratingDto);

            _appDbContext.Ratings.Add(newRating);
            await _appDbContext.SaveChangesAsync();



            var movie = await _appDbContext.Movies
                .Include(m => m.Ratings)
                .FirstOrDefaultAsync(m => m.Id == ratingDto.MovieId);

            if (movie != null)
            {
                // Recalculate the average rating for the movie
                double totalRating = movie.Ratings.Sum(r => r.RatingScore) + newRating.RatingScore;
                int totalRatingsCount = movie.Ratings.Count + 1; // Add 1 for the new rating
                double newAvgRating = totalRating / totalRatingsCount;

                // Update the movie's average rating
                movie.AvgRating = newAvgRating;

                // Save the changes to update the movie record with the new average rating
                await _appDbContext.SaveChangesAsync();
            }

            return _mapper.Map<CreateRatingDto>(newRating);
        }
        public async Task<CreateRatingDto> GetRatingAsync(Guid userID, Guid movieID)
        {
            var rating = await _appDbContext.Ratings.FirstOrDefaultAsync(m => m.UserId == userID && m.MovieId == movieID);
            if (rating == null)
            {
                return null;
            }
            return _mapper.Map<CreateRatingDto>(rating);



        }
    }
}
