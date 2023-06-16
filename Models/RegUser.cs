using System.ComponentModel.DataAnnotations;

namespace CSharp_Login_Reg_Simple.Models
{
    public class RegUser
    {
        [Required]
        [MinLength(1)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        public string LastName { get; set; }

        [Required]
        [MinLength(3)]
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }

    }
}
