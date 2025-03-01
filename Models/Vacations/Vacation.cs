using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models.Vacations
{
    public class Vacation
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int CreatedById { get; set; }
        public User User { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        [ForeignKey("AssignedUser")]
        public int AssignedUserId { get; set; }
        public User AssignedUser { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public VacationStatus Status { get; set; }
    }

}