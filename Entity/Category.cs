using System.ComponentModel.DataAnnotations;

namespace movie_rating_backend.Entity
{
    public class Category
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Movie>? Movies { get; set; }


    }
}
