using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Dto;
using MyApp.Dto.Roles;
using MyApp.Interfaces;
using MyApp.Mappers;
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
            using var transaction = await _context.Database.BeginTransactionAsync();
            var hasher = new PasswordHasher<User>();
            var targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }
            try
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + userDto.Icon?.FileName;
                var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == 1);
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
                    IconPath = uniqueFileName,
                    Age = userDto.Age,
                    RoleId = role.Id,
                    Password = hasher.HashPassword(null, userDto.Password)
                };
                var validateUser = _validator.Validate(userRecord);
                if (validateUser.IsValid)
                {
                    await _context.Users.AddAsync(userRecord);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return userRecord;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<ShowUserDto>> GetAll()
        {
            var result = await _context.Users
                .Include(u => u.Role)
                .Select(u => u.ToShowUserDto())
                .ToListAsync();

            return result;
        }

        public async Task<User> GetById(int id)
        {
            var result = await _context.Users
            .Include(r => r.Role)
            .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<User?> GetByEmail([FromBody] string email)
        {
            var result = await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();

            return result;
        }

        public async Task<ShowUserDto> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == updateRoleDto.UserId);
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == updateRoleDto.RoleId);
            if (user == null)
            {
                throw new KeyNotFoundException("user was not foujnd");
            }
            if (role == null)
            {
                throw new KeyNotFoundException("role was not found");
            }

            user.RoleId = role.Id;
            await _context.SaveChangesAsync();
            return user.ToShowUserDto();
        }
    }
}