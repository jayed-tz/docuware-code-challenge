using System;
namespace DocuwareCodeChallenge.DTOs
{
	public class RegistrationRequest
	{
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string EventId { get; set; }
    }
}

