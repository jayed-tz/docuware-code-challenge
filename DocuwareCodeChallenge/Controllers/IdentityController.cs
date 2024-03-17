using System;
using DocuwareCodeChallenge.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DocuwareCodeChallenge.Data;

namespace DocuwareCodeChallenge.Controllers
{
    [ApiController]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        private static readonly TimeSpan TokenLifetime = TimeSpan.FromDays(5);
        private readonly IConfiguration _config;

        public IdentityController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("token")]
        public IActionResult GenerateToken([FromBody] TokenGenerationRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!);
            var claims = new List<Claim> {
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Email, request.Email)
            };

            using (var context = new DataContext())
            {
                var user = context.Users.FirstOrDefault(it => it.Email.Equals(request.Email));

                if (user != null)
                {
                    claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.UserId, ClaimValueTypes.String));

                    // populate this claim based on some other logic
                    var claim = new Claim(IdentityPolicy.CreatorClaimName, "true", ClaimValueTypes.Boolean);
                    claims.Add(claim);
                }
                else
                {
                    var message = "User not found";
                    return NotFound(message);
                }

            }


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TokenLifetime),
                Issuer = "test.com",
                Audience = "arbitrary.com",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return Ok(jwt);
        }
    }
}

