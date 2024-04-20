using Microsoft.AspNetCore.Mvc;
using movie_rating_backend.Models.DTOs.RatingDtos;
using movie_rating_backend.Services.Interfaces;

namespace movie_rating_backend.Controllers
{
    [ApiController]
    [Route("rating")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost("add_rating")]
        [ActionName(nameof(CreateRatingDto))]
        public async Task<ActionResult<CreateRatingDto>> CreateRatingAsync(CreateRatingDto addRatingDto)
        {
            var getRating = await _ratingService.GetRatingAsync(addRatingDto.UserId, addRatingDto.MovieId);

            if (getRating != null)
            {
                return Conflict("This rating already exist");
            }


            var createdRating = await _ratingService.CreateRatingAsync(addRatingDto);


            if (createdRating != null)
            {

                return CreatedAtAction(nameof(CreateRatingDto), new { userId = createdRating.UserId, movieId = createdRating.MovieId }, createdRating);
            }


            return StatusCode(500, "Failed to add the rating ");


        }
    }
}
