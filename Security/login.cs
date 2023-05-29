using Microsoft.Build.Framework;

namespace Labrary2023.Security
{
    public class login
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
