using System.ComponentModel.DataAnnotations;

namespace AuthenticationDemo.Models.Authentication.Login
{
    //We pass that model as a parameter in Login action method in Authenticationcontroller 

    public class LoginUser
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email Is Required")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        public string password { get; set; }
    }
}
