using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DocuwareCodeChallenge.Models
{
	public class User
	{
        [Key]
        public string UserId { get; set; } = null!;
        public string Email { get; set; } = null!;

        [JsonIgnore]
        public string PasswordHash { get; set; } = null!;
    }
}

