using System.ComponentModel.DataAnnotations;

namespace CSharp_Login_Reg_Simple.Models
{
    public class LogUser
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
