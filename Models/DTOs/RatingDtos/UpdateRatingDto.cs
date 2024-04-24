namespace movie_rating_backend.Models.DTOs.RatingDtos
{
    public class UpdateRatingDto
    {
        
        public int RatingScore { get; set; }
        public string? Comment { get; set; }
    }
}
