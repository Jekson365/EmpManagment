using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Dto.Roles;
using MyApp.Models;

namespace MyApp.Dto
{
    public class ShowUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public RoleDto Role { get; set; }
    }
}