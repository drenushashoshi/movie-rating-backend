using System.ComponentModel.DataAnnotations;

namespace movie_rating_backend.Entity
{
    public class Category
    {
        
        public int Id { get; set; }

        public required string Name { get; set; }

        public List<Movie>? Movies { get; set; }


    }
}
