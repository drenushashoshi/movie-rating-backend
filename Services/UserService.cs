
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using movie_rating_backend.Entity;
using movie_rating_backend.Models.DTOs;
using movie_rating_backend.Helpers;


namespace movie_rating_backend.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly TokenGenerator _tokenGenerator;

        public UserService(AppDbContext appDbContext, IMapper mapper, TokenGenerator tokenGenerator)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _tokenGenerator = tokenGenerator;


        }

        public async Task<UserLoginDto> CreateUser(CreateUserDto newUserDto)
        {
            string hashedPassword = PasswordHelper.HashPassword(newUserDto.Password);
            var newUser = _mapper.Map<User>(newUserDto);

            newUser.Password = hashedPassword;
            newUser.CreatedAt = DateTime.UtcNow;

            _appDbContext.Users.Add(newUser);

            await _appDbContext.SaveChangesAsync();
            


            return _mapper.Map<UserLoginDto>(newUser);
           
        }

        public async Task<string> Login(string username, string password)
        {
            var userExist = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (userExist == null)
            {
                throw new Exception("User not found");

            }

            if (!PasswordHelper.VerifyPassword(password, userExist.Password))
            {
                throw new Exception("Incorrect password");
            }

            var token = _tokenGenerator.GenerateJwtToken(userExist);
            return token;
        }

        public async Task<GetUserDto> GetUserByUsername(String username)
        {
                var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

                if (user == null)
                {
                    return null;
                }
                return _mapper.Map<GetUserDto>(user);



            }

        public async Task<GetUserDto> CheckEmail(String email)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return null;
            }
            return _mapper.Map<GetUserDto>(user);



        }

        public async Task<List<GetUserDto>> GetAllUsers()
        {

            var usersDto = _mapper.ProjectTo<GetUserDto>(_appDbContext.Users);

            return usersDto.ToList();



        }

        

        public async Task<bool> DeleteUserByUsername(String username)
        {
            {
                var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
                if (user == null)
                {
                    return false;
                }

                _appDbContext.Users.Remove(user);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<string> UpdateUserByUsername(String username, CreateUserDto updateUser)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                return "User was not updated : User not found";
            }

            
            user.Email = updateUser.Email;
            user.Username = updateUser.Username;
            user.Password = PasswordHelper.HashPassword(updateUser.Password);
            await _appDbContext.SaveChangesAsync();

            return "User with username" + " " + user.Username +" " + "was updated succsesfully";
        }


        
    }

}

