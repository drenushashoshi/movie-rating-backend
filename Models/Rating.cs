using System.ComponentModel.DataAnnotations;

namespace movie_rating_backend.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public required int MovieId { get; set; }
        public required Movie Movie { get; set; }
        public required int UserId { get; set; }

        public required int RatingScore { get; set; }

        public string? Comment { get; set; }


    }
}
