using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace movie_rating_backend.Entity
{
    public class User
    {
        
        public Guid Id { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }

        public string Email { get; set; }
        public Role Role { get; set; }

        public DateTime CreatedAt { get; set; }



    }
    public enum Role
    {
        User,
        Admin
    }
}
