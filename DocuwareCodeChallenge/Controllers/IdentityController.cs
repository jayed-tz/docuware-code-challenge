using DocuwareCodeChallenge.Identity;
using Microsoft.AspNetCore.Mvc;
using DocuwareCodeChallenge.Services.Interfaces;

namespace DocuwareCodeChallenge.Controllers
{
    [ApiController]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("token")]
        public IActionResult GenerateToken([FromBody] TokenGenerationRequest request)
        {
            try
            {
                return Ok(_identityService.GenerateToken(request));
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
    }
}

