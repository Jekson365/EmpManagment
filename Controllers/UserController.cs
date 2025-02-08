using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyApp.Data;
using MyApp.Dto;
using MyApp.Interfaces;
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
                return BadRequest(new { Errors = new[] { "Imagee is required" } });
            }
            var userRecord = new User
            {
                Name = userModel.Name,
                Surname = userModel.Surname,
                Email = userModel.Email,
            };

            var validateRecord = _validator.Validate(userRecord);
            if (!validateRecord.IsValid)
            {
                return BadRequest(validateRecord);
            }
            var result = await _userRepo.Create(userModel);
            return Ok(result);

        }
    }
}
