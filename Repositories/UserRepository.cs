using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Dto;
using MyApp.Interfaces;
using MyApp.Models;

namespace MyApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IValidator<User> _validator;
        public UserRepository(ApplicationDbContext context, IValidator<User> validator)
        {
            _context = context;
            _validator = validator;
        }
        public async Task<User?> Create(CreateUserDto userDto)
        {
            var targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwroot", "uploads");
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + userDto.Icon?.FileName;
            var filePath = Path.Combine(targetDirectory, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await userDto.Icon.CopyToAsync(stream);
            }

            var userRecord = new User
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Email = userDto.Email,
                IconPath = uniqueFileName
            };

            var validateRecord = _validator.Validate(userRecord);
            if (validateRecord.IsValid)
            {
                await _context.Users.AddAsync(userRecord);
                await _context.SaveChangesAsync();
                return userRecord;
            }
            else {
                return null;
            }
        }
    }
}