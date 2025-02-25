using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Dto.Note;

namespace MyApp.Interfaces
{
    public interface INoteRepository
    {
        Task<CreateNoteDto> Create(CreateNoteDto CreateNoteDto);
        Task<CreateNoteAssignedDto> CreateNoteAssigned(CreateNoteAssignedDto createNoteAssignedDto);
        Task<List<IndexNoteAssignedDto>> GetByUserId(int userId);
    }
}