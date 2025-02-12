using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models.Statuses
{
    public class TaskStatus
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public ICollection<Models.Tasks.Task> Tasks { get; set; } = new List<Tasks.Task>();
    }
}