using System;
using DocuwareCodeChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace DocuwareCodeChallenge.Repositories.Interfaces
{
	public interface IRegistrationRepository
	{
        Task<Registration> AddRegistrationAsync(Registration registration);

        Task<List<Registration>> GetRegistrationsAsync(string eventId);
    }
}

