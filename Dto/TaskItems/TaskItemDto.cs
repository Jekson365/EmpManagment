using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Dto.AssignedTask;
using MyApp.Dto.Comments;
using MyApp.Dto.Statuses;
using MyApp.Dto.Tasks;
using MyApp.Models.Comments;
using MyApp.Models.Statuses;
using MyApp.Models.Tasks;

namespace MyApp.Dto.TaskItems
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
        public List<UserCommentDto>? Comments { get; set; }
        public List<TaskUserDto>? AssignedUsers { get; set; }
    }
}