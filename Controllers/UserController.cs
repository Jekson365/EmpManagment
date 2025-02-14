using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyApp.Data;
using MyApp.Dto;
using MyApp.Dto.Roles;
using MyApp.Interfaces;
using MyApp.Mappers;
using MyApp.Models;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IValidator<User> _validator;
        public readonly ApplicationDbContext _context;
        public readonly IUserRepository _userRepo;
        public UserController(ApplicationDbContext context, IUserRepository userRepo, IValidator<User> validator)
        {
            _context = context;
            _userRepo = userRepo;
            _validator = validator;
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateUserDto userModel)
        {
            if (userModel.Icon is null)
            {
                return BadRequest(new { Errors = new[] { "Image is required" } });
            }
            var result = await _userRepo.Create(userModel);
            return Ok(result.ToCreateUserDto());

        }
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _userRepo.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToShowUserDto());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepo.GetAll();
            return Ok(users);
        }

        [Authorize(Roles = "superadmin")]
        [HttpPut("update_role")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleDto updateRoleDto)
        {
            var result = await _userRepo.UpdateRole(updateRoleDto);

            return Ok(result);
        }
        [HttpGet("current-user")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdClaim))
            {
                return Unauthorized(new { Error = "user not authenticated" });
            }

            if (!int.TryParse(userIdClaim, out int userId))
            {
                return BadRequest(new { Error = "Invalid user ID format" });
            }
            var user = await _userRepo.GetById(userId);

            if (user == null)
            {
                return NotFound(new { Error = "user not found" });
            }

            return Ok(user.ToShowUserDto());
        }
    }
}
