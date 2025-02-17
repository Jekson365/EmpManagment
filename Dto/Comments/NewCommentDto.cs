using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Dto.Comments
{
    public class NewCommentDto
    {
        public string Content { get; set; } = String.Empty;
        public int TaskId { get; set; }
        public int UserId { get; set; }
    }
}