using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using REST_Practice.Data;
using REST_Practice.DTOs;
using REST_Practice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_Practice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountsController(UserManager<IdentityUser> userManager, 
                                  SignInManager<IdentityUser> signInManager,
                                  IConfiguration configuration)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._configuration = configuration;
        }


        private object GetToken(string email)
        {
            var jwt = new JwtServices(_configuration);
            var token = jwt.GenerateSecurityToken(email, "Admin");
            return token;
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles ="Admin")]
        [HttpGet("SomeAuthAction")] // For Test Purposes Only
        public  ActionResult<IEnumerable<LoginDTO>> SomeAuthAction()
        {
            var users = new List<LoginDTO> {
                new RegisterDTO { Email = "ahmad@Blabla.com", Password = "Password.12345" },
                new RegisterDTO { Email = "ali@Blabla.com", Password = "Password.12345" },
                new RegisterDTO { Email = "hassan@Blabla.com", Password = "Password.12345" }
            };
            return Ok(users);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);

            IdentityUser user = await _userManager.FindByEmailAsync(model.Email);

            if (result.Succeeded)
                if (await _userManager.IsEmailConfirmedAsync(user))
                    return Ok(GetToken(user.Email));
                else
                    return BadRequest("Email Confirmation Required");

            return BadRequest();
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            var user = new IdentityUser()
            {
                UserName = model.Email,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(string.Join(" .\n", result.Errors.Select(x => x.Description)));

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string confirmLink = Url.Action("ConfirmEmail", "Accounts", new { email = user.Email, token = token }, Request.Scheme);

            return Ok(confirmLink);
        }

        [HttpGet("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    string resetLink = Url.Action("ResetPassword", "Accounts", new { email = email, token = token }, Request.Scheme);

                    return Ok(resetLink);
                }
                return NotFound(email);
            }
            return BadRequest(email);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromQuery] string email, [FromQuery] string token, [FromBody] ResetPasswordDTO model)
        {
            if (email == null && token == null)
                return BadRequest(email);

            if (!ModelState.IsValid)
                return BadRequest(email);

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return NotFound(email);

            var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
            if (result.Succeeded)
                return Ok(result);
            return BadRequest(string.Join(" .\n", result.Errors.Select(x => x.Description)));
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string email, [FromQuery] string token)
        {
            if (email == null || token == null)
                return BadRequest(email);

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return NotFound(email);

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
                return Ok(result);

            return BadRequest();
        }


    }
}
