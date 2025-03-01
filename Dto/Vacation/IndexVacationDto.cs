using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models;
using MyApp.Models.Vacations;

namespace MyApp.Dto.Vacation
{
    public class IndexVacationDto
    {
        public int Id { get; set; }
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }
        public string Status { get; set; } = String.Empty;
        public UserDto AssignedToUser { get; set; }
        public UserDto CreatedByUser { get; set; }
    }
}