﻿using System.ComponentModel.DataAnnotations;

namespace MVC.Dto
{
    public class AuthRequest
    {
        public string Username { get; set; } = string.Empty;
        
        public string Password { get; set; } = string.Empty;
    }
}