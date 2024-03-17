using System;
using DocuwareCodeChallenge.Data;
using DocuwareCodeChallenge.Models;
using DocuwareCodeChallenge.Repositories.Interfaces;

namespace DocuwareCodeChallenge.Repositories
{
	public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public User? GetUser(string username, string passwordHash)
        {
            return _context.Users.FirstOrDefault(user => user.Email == username && user.PasswordHash == passwordHash);
        }
    }
}

