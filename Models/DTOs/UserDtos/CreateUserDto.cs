using movie_rating_backend.Entity;
using System.ComponentModel.DataAnnotations;

namespace movie_rating_backend.Models.DTOs.UserDtos
{
    public class CreateUserDto
    {


        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is required ")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Email is required ")]

        public string? Email { get; set; }



    }
}
