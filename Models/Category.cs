using System.ComponentModel.DataAnnotations;

namespace movie_rating_backend.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }


    }
}
