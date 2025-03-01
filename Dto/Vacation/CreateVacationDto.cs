using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Dto.Vacation
{
    public class CreateVacationDto
    {
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        public int CreatedById { get; set; }
        public int AssignedUserId { get; set; }
    }
}