using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Dto.Tasks
{
    public class UpdateTaskStatusDto
    {
        public int TaskId { get; set; }
        public int StatusId { get; set; }
    }
}