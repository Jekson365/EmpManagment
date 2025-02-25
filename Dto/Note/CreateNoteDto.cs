using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Dto.Note
{
    public class CreateNoteDto
    {
        public string Content { get; set; } = String.Empty;
        public int UserId { get; set; }
        public List<int> CreatedByIds { get; set; }
    }
}