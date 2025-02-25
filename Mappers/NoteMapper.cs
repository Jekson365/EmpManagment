using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Dto.Note;
using MyApp.Models.Notes;

namespace MyApp.Mappers
{
    public static class NoteMapper
    {
        public static CreateNoteDto ToNote(this CreateNoteDto createNoteDto)
        {
            return new CreateNoteDto
            {
                Content = createNoteDto.Content,
                CreatedByIds = createNoteDto.CreatedByIds
            };
        }
    }
}