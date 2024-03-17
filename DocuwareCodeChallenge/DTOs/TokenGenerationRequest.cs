using System;
namespace DocuwareCodeChallenge.Identity
{
	public class TokenGenerationRequest
	{
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}

