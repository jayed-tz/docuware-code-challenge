using System;
using DocuwareCodeChallenge.DTOs;
using DocuwareCodeChallenge.Models;

namespace DocuwareCodeChallenge.Services.Interfaces
{
	public interface IUserService
	{
        Task<User> AddUser(UserRequest newUser);
    }
}

