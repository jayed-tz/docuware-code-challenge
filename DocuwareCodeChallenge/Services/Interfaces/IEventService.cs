using System;
using System.Security.Claims;
using DocuwareCodeChallenge.DTOs;
using DocuwareCodeChallenge.Models;

namespace DocuwareCodeChallenge.Services.Interfaces
{
	public interface IEventService
	{
        Task<Event> AddEvent(EventRequest newEvent, ClaimsPrincipal user);
        Task<List<Event>> GetEvents();
    }
}

