using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Dto;
using MyApp.Dto.Roles;
using MyApp.Models;

namespace MyApp.Mappers
{
    public static class UserMappers
    {
        public static CreateUserDto ToCreateUserDto(this User userDto)
        {
            return new CreateUserDto
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Email = userDto.Email,
                Age = userDto.Age
            };
        }
        public static ShowUserDto ToShowUserDto(this User userModel)
        {
            return new ShowUserDto
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Role = new RoleDto
                {
                    Id = userModel.Role.Id,
                    Name = userModel.Role.Name
                }
            };
        }
    }
}