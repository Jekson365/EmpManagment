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

        [ForeignKey("CreatedById")]
        public int CreatedById { get; set; }
        public User User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; } = String.Empty;
        [ForeignKey("StatusId")]
        public int StatusId { get; set; }
        [ForeignKey("AssignedToId")]
        public int AssignedToId { get; set; }
        public User AssignedUser { get; set; }
    }
}