using System;
using DocuwareCodeChallenge.Data;
using DocuwareCodeChallenge.Models;
using DocuwareCodeChallenge.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DocuwareCodeChallenge.Repositories
{
	public class RegistrationRepository : IRegistrationRepository
    {
        private readonly DataContext _context;

        public RegistrationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Registration> AddRegistrationAsync(Registration registration)
        {
            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();

            return registration;
        }

        public async Task<List<Registration>> GetRegistrationsAsync(string eventId)
        {
            return await _context.Registrations.Where(e => e.EventId == eventId).ToListAsync(); 
        }

        public async Task<Registration?> GetRegistration(string registrationId)
        {
            return await _context.Registrations.FindAsync(registrationId);
        }
    }
}

