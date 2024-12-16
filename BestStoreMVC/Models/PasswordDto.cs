using System.ComponentModel.DataAnnotations;

namespace BestStoreMVC.Models
{
    public class PasswordDto
    {
        [Required(ErrorMessage = "The current password field is required"), MaxLength(100)]
        public string CurrentPassword { get; set; } = "";

        [Required(ErrorMessage = "The new password field is required"), MaxLength(100)]
        public string NewPassword { get; set; } = "";

        [Required(ErrorMessage = "The confirm password field is required")]
        [Compare("NewPassword", ErrorMessage = "Confirm Password and Password do not match")]
        public string ConfirmPassword { get; set; } = "";
    }
}
