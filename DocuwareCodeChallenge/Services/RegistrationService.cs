using System;
using DocuwareCodeChallenge.DTOs;
using DocuwareCodeChallenge.Models;
using DocuwareCodeChallenge.Repositories.Interfaces;
using System.Security.Claims;
using DocuwareCodeChallenge.Repositories;
using DocuwareCodeChallenge.Services.Interfaces;

namespace DocuwareCodeChallenge.Services
{
	public class RegistrationService: IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public async Task<List<Registration>> GetRegistrationsByEventId(string eventId)
        {
            return await _registrationRepository.GetRegistrationsAsync(eventId);
        }

        public async Task<List<Registration>> GetRegistration(string registrationId)
        {
            return await _registrationRepository.GetRegistrationsAsync(eventId);
        }

        public async Task<Registration> AddRegistration(RegistrationRequest newRegistration)
        {
            var registration = new Registration
            {
                RegistrationId = Guid.NewGuid().ToString(),
                EventId = newRegistration.EventId,
                Name = newRegistration.Name,
                Email = newRegistration.Email,
                Phone = newRegistration.Phone
            };

            return await _registrationRepository.AddRegistrationAsync(registration);
        }
    }
}

