using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models.Comments
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int TaskId { get; set; }
        public Models.Tasks.Task Task { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}