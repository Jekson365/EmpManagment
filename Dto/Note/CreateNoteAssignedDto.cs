using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyApp.Models.Notes;

namespace MyApp.Dto.Note
{
    public class CreateNoteAssignedDto
    {
        public List<int> NoteIds { get; set; }
        public Models.Notes.Note Note { get; set; }
    }
}