using System;
using DocuwareCodeChallenge.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DocuwareCodeChallenge.Identity;
using DocuwareCodeChallenge.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using DocuwareCodeChallenge.Repositories.Interfaces;
using DocuwareCodeChallenge.Utilities;

namespace DocuwareCodeChallenge.Services
{
	public class IdentityService: IIdentityService
    {
        private static readonly TimeSpan TokenLifetime = TimeSpan.FromDays(5);
        private readonly IConfiguration _config;
        private IUserRepository _userRepository;

        public IdentityService(IConfiguration config, IUserRepository userRepository)
		{
            _config = config;
            _userRepository = userRepository;
        }

        public string GenerateToken(TokenGenerationRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!);
            var claims = new List<Claim> {
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Email, request.Username)
            };

            using (var context = new DataContext())
            {
                var user = _userRepository.GetUser(request.Username, HashUtility.ComputeSHA256Hash(request.Password));

                if (user != null)
                {
                    claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.UserId, ClaimValueTypes.String));

                    // ideally, this should be populated based on some other logic
                    var claim = new Claim(IdentityPolicy.CreatorClaimName, "true", ClaimValueTypes.Boolean);
                    claims.Add(claim);
                }
                else
                {
                    throw new Exception("User not found");
                }
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TokenLifetime),
                Issuer = _config["JwtSettings:Issuer"],
                Audience = _config["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

