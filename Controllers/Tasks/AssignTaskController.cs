using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Dto.Tasks;
using MyApp.Models;
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
        [Authorize(Roles = "superadmin")]
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

        [Authorize(Roles = "superadmin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAssignedTask([FromBody] AssignTaskDto assignTaskDto)
        {
            var assignedTask = await _context.AssignedTasks
                .FirstOrDefaultAsync(e => e.TaskId == assignTaskDto.TaskId && e.UserId == assignTaskDto.UserId);

            if (assignedTask == null)
            {
                return NotFound(new { message = "Task assignment not found.", StatusCode = 404 });
            }

            _context.AssignedTasks.Remove(assignedTask);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Task assignment deleted successfully.", assignedTask, StatusCode = 204 });
        }


    }
}