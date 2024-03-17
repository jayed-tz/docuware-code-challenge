using System;
using DocuwareCodeChallenge.Identity;

namespace DocuwareCodeChallenge.Services.Interfaces
{
	public interface IIdentityService
	{
		string GenerateToken(TokenGenerationRequest request);
    }
}

