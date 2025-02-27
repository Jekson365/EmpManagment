using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models.Vacations
{
    public class VacationStatus
    {
        public int Id { get; set; }
        public string Status { get; set; } = String.Empty;
        public ICollection<Vacation> Vacations { get; set; }
    }
}
