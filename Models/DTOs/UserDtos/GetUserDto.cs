using movie_rating_backend.Entity;

namespace movie_rating_backend.Models.DTOs.UserDtos
{
    public class GetUserDto
    {

        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
        public Role Role { get; set; }

    }
}
