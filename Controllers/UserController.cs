using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using movie_rating_backend.Models.DTOs.UserDtos;
using movie_rating_backend.Services.Interfaces;

namespace movie_rating_backend.Controllers
{

    [ApiController]
    [Route("users")]

    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        
        public async Task<ActionResult<UserLoginDto>> CreateUser(CreateUserDto addUserDto)
        {
            var existingUsername = await _userService.GetUserByUsername(addUserDto.Username);
            
            if (existingUsername != null)
            {
                return Conflict("A user with this username already exists");
            }

            var createdUser = await _userService.CreateUser(addUserDto);


            if (createdUser != null)
            {

                return createdUser;
            }


            return StatusCode(500, "Registration failed.");


        }
        [HttpPost("login")]

        public async Task<IActionResult> Login(UserLoginDto request)
        {
           var token = await _userService.Login(request.Username, request.Password);
                return Ok(token);
            
          
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<GetUserDto>> GetUserByUsername(string username)
        {
            var getUser = await _userService.GetUserByUsername(username);

            if (getUser != null) 
            {

                return Ok(getUser);
                
            }

            return NotFound("Ky perdorues nuk ekziston");

        }

        [HttpGet]
        public async Task<ActionResult<List<GetUserDto>>> GetAllUsers()
        {
            var allUsers = await _userService.GetAllUsers();
           
            return Ok(allUsers);
        }

        [HttpDelete("delete/{username}")]
        public async Task<IActionResult> DeleteUserByUsername(String username)
        {
            var user = await _userService.DeleteUserByUsername(username);
            return Ok();
        }

        [HttpPut("update/{username}")]

        public async Task <IActionResult> UpdateUserByUsername(String username, CreateUserDto updateUser)
        {
            var user = await _userService.UpdateUserByUsername(username, updateUser);

            if (user != null)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
