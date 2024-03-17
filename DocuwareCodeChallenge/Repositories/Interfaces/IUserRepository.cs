using System;
using DocuwareCodeChallenge.Models;

namespace DocuwareCodeChallenge.Repositories.Interfaces
{
	public interface IUserRepository
	{
        Task<User> AddUserAsync(User user);
        User? GetUser(string username, string passwordHash);
    }
}

