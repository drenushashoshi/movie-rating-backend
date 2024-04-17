using Microsoft.AspNetCore.Mvc;
using movie_rating_backend.Models.DTOs;
using movie_rating_backend.Services;

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

            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<GetMovieDto>> CreateMovie(CreateMovieDto addMovieDto)
        {
            var existingMovie = await _movieService.GetMovieByTitle(addMovieDto.Title);
            if (existingMovie != null)
            {
                return Conflict("This movie already exist");
            }


            var createdMovie = await _movieService.CreateMovie(addMovieDto);


            if (createdMovie != null)
            {

                return CreatedAtAction(nameof(GetMovieByTitle), new { title = createdMovie.Title }, createdMovie);
            }


            return StatusCode(500, "Failed to create the movie.");


        }
    }
}
