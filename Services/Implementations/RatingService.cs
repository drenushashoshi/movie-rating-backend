using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using movie_rating_backend.Entity;
using movie_rating_backend.Models.DTOs.MovieDtos;
using movie_rating_backend.Models.DTOs.RatingDtos;
using movie_rating_backend.Services.Interfaces;

namespace movie_rating_backend.Services.Implementations
{
    public class RatingService : IRatingService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;
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

                
                double totalRating = movie.Ratings.Sum(r => r.RatingScore) + newRating.RatingScore;
                int totalRatingsCount = movie.Ratings.Count + 1; 
                double newAvgRating = totalRating / totalRatingsCount;

                
                movie.AvgRating = newAvgRating;

                await _appDbContext.SaveChangesAsync();
            }

            return _mapper.Map<CreateRatingDto>(newRating);
        }

        public async Task<List<MovieRatingDto>> GetMoviesRatedByUser(Guid userId)
        {
            var ratingsWithMovieInfo = await _appDbContext.Ratings
        .Where(r => r.UserId == userId)
        .Include(r => r.Movie) // Include the movie
        .Select(r => new MovieRatingDto
        {
            Id = r.Movie.Id,
            Title = r.Movie.Title,
            CoverImageUrl = r.Movie.CoverImageUrl,
            RatingScore = r.RatingScore,
            Comment = r.Comment
        })
        .ToListAsync();

            return ratingsWithMovieInfo;
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

        public async Task<bool> UpdateRatingAsync(Guid movieId,Guid userId,UpdateRatingDto dto)
        {

            var updatedRating = _mapper.Map<Rating>(dto);
            var existingRating = await _appDbContext.Ratings.FirstOrDefaultAsync(r => r.MovieId == movieId && r.UserId == userId);
            
            if(existingRating == null)
            {
                return false;
            }
            
            existingRating.RatingScore = updatedRating.RatingScore;
            existingRating.Comment = updatedRating.Comment;

            
            await _appDbContext.SaveChangesAsync();

            var movie = await _appDbContext.Movies
                .Include(m => m.Ratings)
                .FirstOrDefaultAsync(m => m.Id == movieId);

            if (movie != null)
            {


                double totalRating = movie.Ratings.Sum(r => r.RatingScore);
                int totalRatingsCount = movie.Ratings.Count;
                double newAvgRating = totalRating / totalRatingsCount;


                movie.AvgRating = newAvgRating;

                await _appDbContext.SaveChangesAsync();
            }

            return true;
        }
    }
}
