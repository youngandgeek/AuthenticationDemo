using AuthenticationDemo.Models;
using AuthenticationDemo.Models.Authentication.SignUp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace AuthenticationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager,
           RoleManager<IdentityRole> roleManager,
           IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;

        }
        [HttpPost]
        //pass the RegisterUserModel and the role
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string role)
        {
            /**1st: check if user already exists.
              *2nd: If not Add to db.
              *3rd: Assign a Role.**/
            var userExist = await _userManager.FindByEmailAsync(registerUser.email);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response { Status = "Error", Message = "User Already Exsists please login instead" });

            }
            IdentityUser user = new()
            {
                UserName = registerUser.username,
                Email = registerUser.email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            if (await _roleManager.RoleExistsAsync(role)) { 

                var result = await _userManager.CreateAsync(user, registerUser.password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                     new Response { Status = "Error", Message = "Failed please try again" });


                }
              
                //add role
                await _userManager.AddToRoleAsync(user, role);

                return StatusCode(StatusCodes.Status200OK,
            new Response { Status = "Success", Message = "Account Created Successfully" });
            }

            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  new Response { Status = "Error", Message = "This Role Already Exist" });
            }
        }
    
    }

}
