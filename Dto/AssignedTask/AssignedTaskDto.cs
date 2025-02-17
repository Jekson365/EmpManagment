using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Dto.TaskItems;
using MyApp.Models;

namespace MyApp.Dto.AssignedTask
{
    public class AssignedTaskDto
    {
        public List<TaskUserDto>? Users { get; set; }
        public TaskItemDto Task { get; set; }
    }
}