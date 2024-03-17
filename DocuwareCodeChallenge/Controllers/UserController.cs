using System;
using DocuwareCodeChallenge.DTOs;
using DocuwareCodeChallenge.Models;
using DocuwareCodeChallenge.Repositories.Interfaces;
using DocuwareCodeChallenge.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocuwareCodeChallenge.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<User> Post([FromBody] UserRequest newUser)
        {
            var user = new User
            {
                UserId = Guid.NewGuid().ToString(),
                Email = newUser.Email,
                PasswordHash = HashUtility.ComputeSHA256Hash(newUser.Password)
            };

            await _userRepository.AddAsync(user);
            return user;
        }
    }
}

