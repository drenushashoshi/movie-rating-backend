using System.ComponentModel.DataAnnotations;

namespace movie_rating_backend.Entity
{
    public class Rating
    {

        public Movie Movie { get; set; }

        public Guid MovieId { get; set; }
        
        public User User { get; set; }
        
        public Guid UserId { get; set; }
        public int RatingScore { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? Comment { get; set; }


    }
}
