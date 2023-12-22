using Educonnect.Core.Authentication;
using Educonnect.Core.Models;
using Educonnect.Identity.Service.API.Models.Constants;
using Educonnect.Identity.Service.API.Models.Dto;
using Educonnect.Identity.Service.API.Models.Entities;
using Educonnect.Identity.Service.API.Models.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Educonnect.Identity.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly JwtSettings jwtSettings;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            JwtSettings jwtSettings,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            this.jwtSettings = jwtSettings;
        }
        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> Authenticate([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return Unauthorized(new ResponseModel { Status = "error", Message = "Invalid Login Credential" });
            }
            try
            {
                var usercheck =await _userManager.FindByNameAsync(model.Username);
           
            var user =await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return Unauthorized(new ResponseModel { Status = "error", Message = "Invalid Login Credential" });
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded && !result.RequiresTwoFactor)
            {
                return Unauthorized(new ResponseModel { Status = "error", Message = "Invalid Login Credential" });
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            List<Claim> claims = new() { new Claim(type: Educonnect.Core.Authentication.IdentityConstants.Name, value: model.Username) };
            claims.Add(new Claim(type: Educonnect.Core.Authentication.IdentityConstants.Email, value: user.Email));
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(type: Educonnect.Core.Authentication.IdentityConstants.Role, value: userRole));
            }
           
                var Token = new UserTokens();
                Token = JwtHelpers.GenerateTokenkey(new UserTokens()
                {
                    email = user.Email,
                    userId = user.Id,
                    userName = user.UserName,
                }, jwtSettings);
                await _userManager.UpdateAsync(user);
                return Ok(new ResponseModel { Status = "success", Message = "User created successfully!", Data = Token });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = ResponseStatus.Error, Message = "User already exists!" });

            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                PhoneNumber = model.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = ResponseStatus.Error, Message = "User creation failed! Please check user details and try again." });

            return Ok(new ResponseModel { Status = "Success", Message = "User created successfully!" });
        }
    }
}
