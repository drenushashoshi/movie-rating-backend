/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using movie_rating_backend.Entity;

namespace movie_rating_backend.Controllers
{
    [Route("api/asa/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]User login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<string>> Get()
		{
    		return new string[] { "value1", "value2", "value3", "value4", "value5" };
		}

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[] {
        		new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
        		new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
        		new Claim("DateOfJoing", userInfo.CreatedAt.ToString("yyyy-MM-dd")),
        		new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticateUser(User login)
        {
            //Validate the User Credentials
            if (login.Username != "" && login.Email != "" && login.Password != "")
            {
            	return login;
            }
			return null;
        }
    }
}
*/