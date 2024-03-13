using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RealEstate.Contract.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AccountSignInRequest login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email!, login.Password!, false, false);

            if (!result.Succeeded) return BadRequest(new AccountSignInResponse { Success = false, Error = "Username and password are invalid." });

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, login.Email!)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["Jwt:ExpireInDays"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:ValidIssuer"],
                _configuration["Jwt:ValidAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return Ok(new AccountSignInResponse { Success = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
