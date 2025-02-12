using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MyApp.Models.Tasks;

namespace MyApp.Models.Tasks
{
    public class AssignedTask
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("TaskId")]
        public Task Task { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}