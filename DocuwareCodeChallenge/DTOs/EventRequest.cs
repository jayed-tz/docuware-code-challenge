using System;
namespace DocuwareCodeChallenge.DTOs
{
	public class EventRequest
	{
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set; }
        public required string StartTime { get; set; }
        public required int Duration { get; set; }
    }
}

