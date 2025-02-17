using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Dto.User
{
    public class CommentUserDto
    {
        public string Name { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;
        public string IconPath { get; set; } = String.Empty;
    }
}