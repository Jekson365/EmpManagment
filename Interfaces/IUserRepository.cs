using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Dto;
using MyApp.Models;

namespace MyApp.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Create(CreateUserDto userDto);
    }
}