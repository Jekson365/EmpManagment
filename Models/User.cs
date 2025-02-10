using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public int Age { get; set; }
        public string? IconPath { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; } = String.Empty;
    }
}