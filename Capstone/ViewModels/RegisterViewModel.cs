using System.ComponentModel.DataAnnotations;

namespace Capstone.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Parent?")]
        public bool IsParent { get; set; }

        [Required]
        [Display(Name = "Your Name")]
        public string FirstName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}