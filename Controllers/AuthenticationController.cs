using AuthenticationDemo.Models;
using AuthenticationDemo.Models.Authentication.Login;
using AuthenticationDemo.Models.Authentication.SignUp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        //instances of Identity: UserManager ,RoleManager and IConfiguration to access configuration settings among App.
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



        //registration action method 

        [HttpPost]
        //pass the RegisterUserModel and the role
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string role)
        {
            /**1st: check if user already exists.
              *2nd: If not Add to db.
              *3rd: Assign a Role.**/

            var userExist = await _userManager.FindByEmailAsync(registerUser.email);
            
            //if exists throw an error
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response { Status = "Error", Message = "User Already Exsists please login instead" });

            }
            //if not, create new user
            IdentityUser user = new()
            {
                UserName = registerUser.username,
                Email = registerUser.email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            //check if role exists
            if (await _roleManager.RoleExistsAsync(role))
            {
                
                var result = await _userManager.CreateAsync(user, registerUser.password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                     new Response { Status = "Error", Message = "Failed please try again" });


                }

                //assign a role to the user
            
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

        
        [HttpPost]
        [Route("login")]

        //pass the LoginUserModel and the role
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
            //find the user by email
            var user = await _userManager.FindByEmailAsync(loginUser.email);

            //check if the user exists, password validation
            if (user != null && await _userManager.CheckPasswordAsync(user, loginUser.password))
            {
                // User is authenticated successfully
                var roles = await _userManager.GetRolesAsync(user);

                /** TODO: Add any additional authentication-related tasks here
                /* Generate a JWT token
                /*var token = GenerateJwtToken(user, roles);**/

                // Return success  msg along with the token
                //Token = token,
               
                return Ok(new {  Message = "Login successful" });
            }

            //else return Authentication failed
            return Unauthorized(new { Message = "Invalid email or password" });
        }

      /**JWT Authentication 
       * 
       * private string GenerateJwtToken(IdentityUser user, IList<string> roles)
        {
            // TODO: Implement your JWT token generation logic here
            // You can use a library like System.IdentityModel.Tokens.Jwt for this purpose

            // Example (using a hypothetical JwtSecurityTokenHandler):
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"); // Replace with a secure secret key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            // Add additional claims based on user roles or other attributes
        }),
                Expires = DateTime.UtcNow.AddHours(1), // Set token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Create and write the token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
      **/
    }

}
