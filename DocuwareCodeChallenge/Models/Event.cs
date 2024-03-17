using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocuwareCodeChallenge.Models
{
	public class Event
	{
        [Key]
        public string EventId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [ForeignKey("Creator")]
        public string CreatorId { get; set; } = null!;
        public User? Creator { get; set; }
    }
}

