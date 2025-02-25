using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Dto.Note;
using MyApp.Interfaces;
using MyApp.Repositories;

namespace MyApp.Controllers.Notes
{
    [ApiController]
    [Route("api/note")]
    public class NoteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly INoteRepository _noteRepo;
        public NoteController(ApplicationDbContext context, INoteRepository noteRepo)
        {
            _context = context;
            _noteRepo = noteRepo;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNoteDto createNoteDto)
        {
            var result = await _noteRepo.Create(createNoteDto);

            if (result == null)
            {
                return BadRequest("invalid data");
            }

            return Ok(result);
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] int userId)
        {
            var result = await _noteRepo.GetByUserId(userId);

            return Ok(result);
        }
    }
}