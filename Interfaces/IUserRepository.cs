using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Dto;
using MyApp.Dto.Roles;
using MyApp.Models;

namespace MyApp.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Create(CreateUserDto userDto);
        Task<User> GetById(int id);
        Task<List<ShowUserDto>> GetAll();
        Task<ShowUserDto> UpdateRole(UpdateRoleDto updateRoleDto);
        Task<User?> GetByEmail(string Email);
        Task<List<User>> GetBySuperAdmin();
    }
}