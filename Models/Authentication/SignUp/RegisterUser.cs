using System.ComponentModel.DataAnnotations;

namespace AuthenticationDemo.Models.Authentication.SignUp
{
    //We pass that model as a parameter in registration action method in Authenticationcontroller 

    public class RegisterUser
    {
      //some constraints using data annotation 
        [Required(ErrorMessage = "Username Is Required")]
        public string username { get; set; }
        
        [EmailAddress]
        [Required(ErrorMessage ="Email Is Required")]
        public string email { get; set; }

        [Required(ErrorMessage ="Password Is Required")]
        public string password { get; set; }

        /**
        
        [Required("Password doesn't match")]
        [Compare("password",ErrorMessage = "Password doesn't match")]
        public string? ConfirmPassword { get; set; }
    **/
        }
}
