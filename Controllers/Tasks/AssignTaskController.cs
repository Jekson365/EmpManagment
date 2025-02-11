using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Dto.Tasks;
using MyApp.Models.Tasks;

namespace MyApp.Controllers.Tasks
{
    [ApiController]
    [Route("api/task/assign")]
    public class AssignTaskController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AssignTaskController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AssignTask([FromBody] AssignTaskDto assignTaskDto)
        {
            var assign = new AssignedTask
            {
                TaskId = assignTaskDto.TaskId,
                UserId = assignTaskDto.UserId
            };

            await _context.AssignedTasks.AddAsync(assign);
            await _context.SaveChangesAsync();

            return Ok(assign);
        }
        
    }
}