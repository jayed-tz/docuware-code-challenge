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
            optionsBuilder.UseSqlServer(@"Server=database-alpha.chqi6a6469hf.us-east-1.rds.amazonaws.com,1433;Database=Docuware;User Id=admin;Password=382ddea49041f34293deed49dda43a5a;TrustServerCertificate=true;");
        }
    }
}

