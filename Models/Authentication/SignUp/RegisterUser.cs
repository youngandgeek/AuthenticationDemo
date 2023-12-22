using System.ComponentModel.DataAnnotations;

namespace AuthenticationDemo.Models.Authentication.SignUp
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Username Is Required")]
        public string UserName { get; set; }
        
        [EmailAddress]
        [Required(ErrorMessage ="Email Is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password Is Required")]
        public string Password { get; set; }
    }
}
