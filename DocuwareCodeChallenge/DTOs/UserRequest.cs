using System;
namespace DocuwareCodeChallenge.DTOs
{
	public class UserRequest
	{
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}

