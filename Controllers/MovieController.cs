using Microsoft.AspNetCore.Mvc;
using movie_rating_backend.Models.DTOs.MovieDtos;
using movie_rating_backend.Services.Interfaces;

namespace movie_rating_backend.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MovieController: ControllerBase
    {
        public readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetMovieDto>>> GetAllMovies()
        {
            var allMovies = await _movieService.GetAllMovies();
            return Ok(allMovies);
        }

        [HttpGet("{title}")]
        public async Task<ActionResult<GetMovieDto>> GetMovieByTitle(string title)
        {
            var movie = await _movieService.GetMovieByTitle(title);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost("create")]
        [ActionName(nameof(GetMovieDto))]
        public async Task<ActionResult<GetMovieDto>> CreateMovie(CreateMovieDto addMovieDto)
        {
            var existingMovie = await _movieService.GetMovieByTitle(addMovieDto.Title);
            if (existingMovie != null)
            {
                return Ok("This movie already exist");
            }


            var createdMovie = await _movieService.CreateMovie(addMovieDto);
            var avgRating = await _movieService.GetAverageRating(createdMovie.Id);


            if (createdMovie != null)
            {

                return CreatedAtAction(nameof(GetMovieDto), new { avgRating = createdMovie.AvgRating }, createdMovie);
            }


            return StatusCode(500, "Failed to create the movie.");


        }

    }
}
