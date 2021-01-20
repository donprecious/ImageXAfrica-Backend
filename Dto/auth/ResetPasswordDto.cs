using System.ComponentModel.DataAnnotations;

namespace ImageAfricaProject.Dto.auth
{
    public class ResetPasswordDto
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Token { get; set; }
    }
}