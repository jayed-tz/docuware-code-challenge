using System;
using DocuwareCodeChallenge.DTOs;
using DocuwareCodeChallenge.Models;
using System.Security.Claims;

namespace DocuwareCodeChallenge.Services.Interfaces
{
	public interface IRegistrationService
	{
        Task<Registration> AddRegistration(RegistrationRequest newRegistration);
        Task<List<Registration>> GetRegistrationsByEventId(string eventId);
    }
}

