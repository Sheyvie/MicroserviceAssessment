﻿using System.ComponentModel.DataAnnotations;

namespace SocialMedia_Auth.Models.Dtos
{
    public class LoginRequestDto
    {
        [Required]

        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
