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
            if (await _roleManager.RoleExistsAsync(role))
            {

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


        [HttpPost]
        [Route("login")]
        //pass the RegisterUserModel and the role
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
            var user = await _userManager.FindByEmailAsync(loginUser.email);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginUser.password))
            {
                // User is authenticated successfully
                var roles = await _userManager.GetRolesAsync(user);

                // TODO: Add any additional authentication-related tasks here

                // Generate a JWT token
                var token = GenerateJwtToken(user, roles);

                // Return success along with the token
                return Ok(new { Token = token, Message = "Login successful" });
            }

            // Authentication failed
            return Unauthorized(new { Message = "Invalid email or password" });
        }

        private string GenerateJwtToken(IdentityUser user, IList<string> roles)
        {
            // TODO: Implement your JWT token generation logic here
            // You can use a library like System.IdentityModel.Tokens.Jwt for this purpose

            // Example (using a hypothetical JwtSecurityTokenHandler):
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("your-secret-key"); // Replace with a secure secret key
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
    }

}
