using System;
using DocuwareCodeChallenge.DTOs;
using DocuwareCodeChallenge.Models;
using DocuwareCodeChallenge.Repositories.Interfaces;
using DocuwareCodeChallenge.Services.Interfaces;
using DocuwareCodeChallenge.Utilities;

namespace DocuwareCodeChallenge.Services
{
	public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
		{
            _userRepository = userRepository;
        }

        public async Task<User> AddUser(UserRequest newUser)
        {
            var user = new User
            {
                UserId = Guid.NewGuid().ToString(),
                Email = newUser.Email,
                PasswordHash = HashUtility.ComputeSHA256Hash(newUser.Password)
            };

            return await _userRepository.AddUserAsync(user);
        }
    }
}

