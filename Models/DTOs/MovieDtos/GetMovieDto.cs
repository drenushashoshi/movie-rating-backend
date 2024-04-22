using System.ComponentModel.DataAnnotations;

namespace movie_rating_backend.Models.DTOs.MovieDtos
{
    public class GetMovieDto
    {
        public Guid Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string? CoverImageUrl { get; set; }
        public double AvgRating { get; set; }
    }
}
