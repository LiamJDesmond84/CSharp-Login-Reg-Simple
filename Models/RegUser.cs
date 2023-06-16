using System.ComponentModel.DataAnnotations;

namespace CSharp_Login_Reg_Simple.Models
{
    public class RegUser
    {
        [Required]
        [MinLength(1)]
        private string FirstName;

        [Required]
        [MinLength(1)]
        private string LastName;

        [Required]
        [MinLength(3)]
        private string Password;

        [EmailAddress]
        private string Email;

    }
}
