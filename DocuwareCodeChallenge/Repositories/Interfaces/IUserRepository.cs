using System;
using DocuwareCodeChallenge.Models;

namespace DocuwareCodeChallenge.Repositories.Interfaces
{
	public interface IUserRepository
	{
        Task<int> AddAsync(User user);
    }
}

