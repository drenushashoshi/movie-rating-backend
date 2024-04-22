using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace movie_rating_backend.Entity
{
    public class User
    {
        
        public Guid Id { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }

        public string Email { get; set; }
        public Role Role { get; set; } = Role.User;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;



    }
    public enum Role
    {
        [Description("user")]
        User = 0,
        [Description("admin")]
        Admin = 1
    }
}
