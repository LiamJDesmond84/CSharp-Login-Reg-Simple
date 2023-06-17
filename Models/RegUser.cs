using System.ComponentModel.DataAnnotations;

namespace CSharp_Login_Reg_Simple.Models
{
    public class RegUser
    {
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }


        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords must match, Try again !")]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
