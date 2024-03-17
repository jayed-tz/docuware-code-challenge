using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocuwareCodeChallenge.Models
{
	public class Registration
	{
        [Key]
        public string RegistrationId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        [ForeignKey("Event")]
        public string EventId { get; set; } = null!;
        public Event? Event { get; set; }
    }
}

