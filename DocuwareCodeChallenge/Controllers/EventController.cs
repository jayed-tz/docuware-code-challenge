using DocuwareCodeChallenge.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DocuwareCodeChallenge.Models;
using DocuwareCodeChallenge.DTOs;
using DocuwareCodeChallenge.Services.Interfaces;

namespace DocuwareCodeChallenge.Controllers
{
    [ApiController]
    [Route("events")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetEvent()
        {
            return await _eventService.GetEvents();
        }

        [Authorize]
        [RequireClaim(IdentityPolicy.CreatorClaimName, "true")]
        [HttpPost("create")]
        public async Task<ActionResult<Event>> CreateEvent([FromBody]EventRequest newEvent)
        {
            try
            {
                var createdEvent = await _eventService.AddEvent(newEvent, HttpContext.User);

                return CreatedAtAction(nameof(CreateEvent), new { eventId = createdEvent.EventId }, createdEvent);
            } catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }

        }
    }
}