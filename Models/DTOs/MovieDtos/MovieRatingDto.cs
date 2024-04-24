using movie_rating_backend.Entity;

namespace movie_rating_backend.Models.DTOs.MovieDtos
{
    public class MovieRatingDto
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }
        public string? CoverImageUrl { get; set; }
        public int RatingScore { get; set; }
        public string Comment {  get; set; }

        public List<Rating>? Ratings { get; set; }
    }
}
