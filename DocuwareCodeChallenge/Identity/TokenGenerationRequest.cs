using System;
namespace DocuwareCodeChallenge.Identity
{
	public class TokenGenerationRequest
	{
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

