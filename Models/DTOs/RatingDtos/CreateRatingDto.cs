namespace movie_rating_backend.Models.DTOs.RatingDtos
{
    public class CreateRatingDto
    {
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
        public int RatingScore { get; set; }
        public string? Comment { get; set; }
    }
}
