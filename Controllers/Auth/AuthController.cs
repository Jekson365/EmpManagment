using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Dto.Auth;
using MyApp.Interfaces;
using MyApp.Models;
using MyApp.Repositories;

namespace MyApp.Controllers.Auth
{

    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;
        public AuthController(IUserRepository userRepo, ApplicationDbContext context)
        {
            _context = context;
            _userRepo = userRepo;
            _passwordHasher = new PasswordHasher<User>();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginParams)
        {
            var user = await _userRepo.GetByEmail(loginParams.Email);
            _context.Entry(user).Reference(u => u.Role).Load();
            if (user != null)
            {
                var passwordVerified = _passwordHasher.VerifyHashedPassword(user, user.Password, loginParams.Password);
                if (passwordVerified == PasswordVerificationResult.Failed)
                {
                    return Unauthorized(new { message = "not authorized" });
                }
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.Role.Name)
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(7)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return Ok(new { message = "Logged in successfully",token = ""});
            }

            return Unauthorized(new { message = "Invalid credentials" });
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(new { message = "Logged out successfully" });
        }
    }
}