using movie_rating_backend.Models.DTOs;

namespace movie_rating_backend.Services
{
    public interface IUserService
    {
        Task<GetUserDto> GetUserByUsername(String username);

        Task<GetUserDto> CheckEmail(String email);
        Task<UserLoginDto> CreateUser(CreateUserDto newUser);
        Task<List<GetUserDto>> GetAllUsers();
        Task<bool> DeleteUserByUsername(String username);
        Task<string> Login(string username, string password);

        Task<string> UpdateUserByUsername(string username, CreateUserDto updateUser);

    }
}

