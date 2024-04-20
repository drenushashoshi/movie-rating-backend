using System.ComponentModel.DataAnnotations;

namespace movie_rating_backend.Entity
{
    public class Movie
    {
        
        public Guid Id { get; set; }
        
        public string? Title { get; set; }
        
        public int Year { get; set; }
        
        public  string? Description { get; set; }

        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public string? CoverImageUrl { get; set; }

        public double AvgRating { get; set; }
        
       

        

        public List<Rating>? Ratings { get; set; }


    }
}
