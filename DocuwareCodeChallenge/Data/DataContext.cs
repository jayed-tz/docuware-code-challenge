using System;
using DocuwareCodeChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace DocuwareCodeChallenge.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"");
        }
    }
}

