using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        [HttpGet("token")]
        public IActionResult GetToken()
        {
            try
            {
                Console.WriteLine("➡ Generating token...");
                var token = GenerateJSONWebToken(1, "Admin");
                Console.WriteLine("Token generated.");
                return Ok(token);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return StatusCode(500, "Something went wrong: " + ex.Message);
            }
        }
        
        private string GenerateJSONWebToken(int userId, string userRole)
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecretkey1234567890abcd"
));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, userRole),
                new Claim("UserId", userId.ToString())
            };

      var token = new JwtSecurityToken(
          issuer: "mySystem",
          audience: "myUsers",
          claims: claims,
          expires: DateTime.Now.AddMinutes(2),
          signingCredentials: credentials
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
    }
}
