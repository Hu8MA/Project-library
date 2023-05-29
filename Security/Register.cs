using System.ComponentModel.DataAnnotations;

namespace Labrary2023.Security
{
    public class Register
    {
        [Required]
        [RegularExpression(@"[@A-Za-z]{2,6}", ErrorMessage = "user name is incorrect")]
        public string username { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@gmail.com", ErrorMessage = "email is incorrect")]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        [Compare("password", ErrorMessage = "have error rewrite the password in correct")]
        public string configpassword { get; set; }
    }
}
