using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImageAfricaProject.Dto
{
    public class CreateUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } 

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImageUrl { get; set; } 

        
    }
}
