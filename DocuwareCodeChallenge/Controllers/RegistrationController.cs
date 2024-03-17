using System;
using DocuwareCodeChallenge.Data;
using DocuwareCodeChallenge.DTOs;
using DocuwareCodeChallenge.Identity;
using DocuwareCodeChallenge.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocuwareCodeChallenge.Controllers
{
    [ApiController]
    [Route("registrations")]
    public class RegistrationController : ControllerBase
    {
        [RequireClaim(IdentityPolicy.CreatorClaimName, "true")]
        [HttpGet]
        public IEnumerable<Registration> Get()
        {
            using (var context = new DataContext())
            {
                return context.Registrations.ToList();
            }
        }


        [AllowAnonymous]
        [HttpPost("create")]
        public Registration Post([FromBody] RegistrationRequest newRegistration)
        {
            var registration = new Registration
            {
                RegistrationId = Guid.NewGuid().ToString(),
                EventId = newRegistration.EventId,
                Name = newRegistration.Name,
                Email = newRegistration.Email,
                Phone = newRegistration.Phone
            };
            using (var context = new DataContext())
            {
                context.Registrations.Add(registration);
                context.SaveChanges();
            }

            return registration;
        }

    }
}

