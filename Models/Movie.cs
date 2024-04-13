using System.ComponentModel.DataAnnotations;

namespace movie_rating_backend.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public  string Description { get; set; }

        [Required]
        public ICollection<Category> Categories { get; set; }

        public ICollection<Rating> Ratings { get; set; }


    }
}
