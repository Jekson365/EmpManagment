using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models.Notes
{
    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; } = String.Empty;
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User user { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}