using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models.Tasks;

namespace MyApp.Models.Tasks
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public ICollection<AssignedTask> AssignedTasks { get; set; } = new List<AssignedTask>();
        public int TaskStatusId { get; set; } = 1;
        public Models.Statuses.TaskStatus TaskStatus { get; set; }

    }
}