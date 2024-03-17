using System;
using DocuwareCodeChallenge.DTOs;
using DocuwareCodeChallenge.Models;
using DocuwareCodeChallenge.Services.Interfaces;

namespace DocuwareCodeChallenge.Services
{
	public class UserService: IUserService
    {
		public UserService()
		{
		}

        public Task<User> AddUser(UserRequest newUser)
        {
            throw new NotImplementedException();
        }
    }
}

