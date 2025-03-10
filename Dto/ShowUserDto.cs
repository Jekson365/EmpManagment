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
        public string Surname { get; set; } = String.Empty;
        public string IconPath { get; set; } = String.Empty;
        public RoleDto Role { get; set; }
        public string Email { get; set; } = String.Empty;
        public int Age { get; set; }
        public string TrustedContact { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public DateTime BirthDate { get; set; }
        public string Position { get; set; } = String.Empty;
        public DateTime HiredDate { get; set; }
    }
}