using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Dto
{
    public class CreateUserDto
    {
        public string Name { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public int Age { get; set; }
        public IFormFile? Icon { get; set; }
        public string Password { get; set; } = String.Empty;
        public string TrustedContact { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public DateTime BirthDate { get; set; }
        public string Position { get; set; } = String.Empty;
        public DateTime HiredDate { get; set; }
    }
}