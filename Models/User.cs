using System.ComponentModel.DataAnnotations;

namespace movie_rating_backend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        public DateTime CreatedAt { get; set; }


    }
}
