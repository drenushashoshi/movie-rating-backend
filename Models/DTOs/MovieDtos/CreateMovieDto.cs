using System.ComponentModel.DataAnnotations;

namespace movie_rating_backend.Models.DTOs.MovieDtos
{
    public class CreateMovieDto
    {
        [Required(ErrorMessage = "Title of the movie is required ")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Description of the movie is required ")]
        public string? Description { get; set; }
        public int Year { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "The movie cover image is required ")]
        public string? CoverImageUrl { get; set; }
    }
}
