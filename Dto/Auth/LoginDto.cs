using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Dto.Auth
{
    public class LoginDto
    {
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;

    }
}