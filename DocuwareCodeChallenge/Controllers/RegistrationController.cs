using DocuwareCodeChallenge.DTOs;
using DocuwareCodeChallenge.Identity;
using DocuwareCodeChallenge.Models;
using DocuwareCodeChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocuwareCodeChallenge.Controllers
{
    [ApiController]
    [Route("registrations")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [Authorize]
        [RequireClaim(IdentityPolicy.CreatorClaimName, "true")]
        [HttpGet]
        public async Task<ActionResult<List<Registration>>> GetByEvent([FromQuery] string eventId)
        {
            return await _registrationService.GetRegistrationsByEventId(eventId);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<ActionResult<Registration>> CreateRegistration([FromBody] RegistrationRequest newRegistration)
        {
            try
            {
                var createdRegistration = await _registrationService.AddRegistration(newRegistration);

                return CreatedAtAction(nameof(CreateRegistration), new { registrationId = createdRegistration.RegistrationId }, createdRegistration);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }

        }

    }
}

