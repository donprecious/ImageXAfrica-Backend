using System.ComponentModel.DataAnnotations;

namespace ImageAfricaProject.Dto.auth
{
    public class ForgotPasswordDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}