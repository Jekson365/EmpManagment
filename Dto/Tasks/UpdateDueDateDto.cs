using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Dto.Tasks
{
    public class UpdateDueDateDto
    {
        public DateTime EndDate { get; set; }
        public int TaskId { get; set; }
    }
}