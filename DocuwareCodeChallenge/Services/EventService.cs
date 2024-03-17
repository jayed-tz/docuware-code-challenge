using System;
using System.Security.Claims;
using DocuwareCodeChallenge.Data;
using DocuwareCodeChallenge.DTOs;
using DocuwareCodeChallenge.Models;
using DocuwareCodeChallenge.Repositories;
using DocuwareCodeChallenge.Repositories.Interfaces;
using DocuwareCodeChallenge.Services.Interfaces;

namespace DocuwareCodeChallenge.Services
{
	public class EventService: IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
		{
            _eventRepository = eventRepository;
        }

        public async Task<List<Event>> GetEvents()
        {
            return await _eventRepository.GetEventsAsync();
        }

        public async Task<Event> AddEvent(EventRequest newEvent, ClaimsPrincipal user)
        {
            Claim? subClaim = user?.FindFirst(ClaimTypes.NameIdentifier);

            if (subClaim == null)
            {
                throw new Exception("Event creator not found");
            }

            var eventToCreate = new Event
            {
                EventId = Guid.NewGuid().ToString(),
                Name = newEvent.Name,
                Description = newEvent.Description,
                Location = newEvent.Location,
                StartTime = DateTime.Parse(newEvent.StartTime),
                EndTime = (DateTime.Parse(newEvent.StartTime)).AddMinutes(newEvent.Duration),
                CreatorId = subClaim.Value
            };

            return await _eventRepository.AddEventAsync(eventToCreate);
        }
    }
}

