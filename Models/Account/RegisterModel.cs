using System.ComponentModel.DataAnnotations;

namespace SoccerManageApp.Models.Account {
    public class RegisterModel {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType (DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType (DataType.Password)]
        [Compare ("Password")]
        [Display(Name="Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}