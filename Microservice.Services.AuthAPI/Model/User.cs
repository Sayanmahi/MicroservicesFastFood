﻿using System.ComponentModel.DataAnnotations;

namespace Microservice.Services.AuthAPI.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email in not valid")]
        public string Email { get; set; }
        public string userType { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
