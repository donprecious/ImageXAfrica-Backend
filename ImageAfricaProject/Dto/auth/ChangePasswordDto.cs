using System.ComponentModel.DataAnnotations;

namespace ImageAfricaProject.Dto.auth
{
    public class ChangePasswordDto
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}