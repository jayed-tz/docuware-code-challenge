using System;
namespace DocuwareCodeChallenge.Identity
{
	public class TokenGenerationRequest
	{
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}

