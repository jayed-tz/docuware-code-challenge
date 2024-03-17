using System;
using DocuwareCodeChallenge.Models;

namespace DocuwareCodeChallenge.Repositories.Interfaces
{
	public interface IEventRepository
	{
        Task<Event> AddAsync(Event newEvent);
        Task<List<Event>> GetEventsAsync();
    }
}

