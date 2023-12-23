using System.ComponentModel.DataAnnotations;

namespace AuthenticationDemo.Models.Authentication.Login
{
    public class LoginUser
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email Is Required")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        public string password { get; set; }
    }
}
