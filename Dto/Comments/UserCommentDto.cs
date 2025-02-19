using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Dto.User;
using MyApp.Models;

namespace MyApp.Dto.Comments
{
    public class UserCommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; }
        public CommentUserDto? User { get; set; }
    }
}