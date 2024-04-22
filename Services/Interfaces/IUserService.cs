using movie_rating_backend.Models.DTOs.UserDtos;

namespace movie_rating_backend.Services.Interfaces
{
    public interface IUserService
    {
        Task<GetUserDto> GetUserByUsername(string username);

        Task<GetUserDto> CheckEmail(string email);
        Task<UserLoginDto> CreateUser(CreateUserDto newUser);
        Task<List<GetUserDto>> GetAllUsers();
        Task<bool> DeleteUserByUsername(string username);
        Task<string> Login(string username, string password);

        Task<string> UpdateUserByUsername(string username, CreateUserDto updateUser);

    }
}

