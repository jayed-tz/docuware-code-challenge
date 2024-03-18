using DocuwareCodeChallenge.DTOs;
using DocuwareCodeChallenge.Models;
using DocuwareCodeChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocuwareCodeChallenge.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserRequest newUser)
        {
            try
            {
                var createdUser = await _userService.AddUser(newUser);

                return CreatedAtAction(nameof(CreateUser), new { userId = createdUser.UserId }, createdUser);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
    }
}

