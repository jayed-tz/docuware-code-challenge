using System;
using DocuwareCodeChallenge.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DocuwareCodeChallenge.Controllers
{
    [ApiController]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        private static readonly TimeSpan TokenLifetime = TimeSpan.FromDays(5); // IMP: long lived
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
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, "test", ClaimValueTypes.String));
            var claim = new Claim(IdentityPolicy.CreatorClaimName, "true", ClaimValueTypes.Boolean);
            claims.Add(claim);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TokenLifetime),
                Issuer = _config["JwtSettings:Issuer"],
                Audience = _config["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return Ok(jwt);
        }
    }
}

