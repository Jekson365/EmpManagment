using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Dto;
using MyApp.Dto.Note;
using MyApp.Interfaces;
using MyApp.Mappers;
using MyApp.Models.Notes;

namespace MyApp.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _context;
        public NoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CreateNoteDto> Create(CreateNoteDto CreateNoteDto)
        {
            var newNote = await _context.Notes.AddAsync(new Note { Content = CreateNoteDto.Content, UserId = CreateNoteDto.UserId });
            await _context.SaveChangesAsync();

            var createdNote = await _context.Notes.OrderByDescending(n => n.Id).FirstOrDefaultAsync();

            foreach (int userId in CreateNoteDto.CreatedByIds)
            {
                var assignedNote = await _context.NotesAssigned.AddAsync(new NoteAssigned { UserId = userId, NoteId = createdNote.Id });
                await _context.SaveChangesAsync();
            }


            return new CreateNoteDto
            {
                Content = CreateNoteDto.Content
            };
        }

        public Task<CreateNoteAssignedDto> CreateNoteAssigned(CreateNoteAssignedDto createNoteAssignedDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IndexNoteAssignedDto>> GetByUserId(int userId)
        {
            var notesWithUsers = await _context.NotesAssigned
                .Include(na => na.Note)
                .Include(u => u.user)
                .Where(na => na.UserId == userId)
                .Select(na => new IndexNoteAssignedDto
                {
                    IconPath = na.Note.user.IconPath,
                    Content = na.Note.Content,
                    UserId = na.UserId
                })
                .ToListAsync();
            return notesWithUsers;
        }
    }
}