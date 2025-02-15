using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Dto.Tasks;
using MyApp.Models.Tasks;

namespace MyApp.Controllers.Tasks
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "superadmin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewTaskDto newTaskDto)
        {
            var newTask = new Models.Tasks.Task
            {
                Title = newTaskDto.Title,
                Description = newTaskDto.Description
            };

            await _context.Tasks.AddAsync(newTask);
            await _context.SaveChangesAsync();

            return Ok(newTask);
        }
        public async Task<IActionResult> GetAll()
        {
            var result = await _context.Tasks
                .Select(t => new
                {
                    t.Id,
                    t.Title,
                    t.Description,
                    Status = t.TaskStatus.Name,
                    StatusId = t.TaskStatus.Id,
                    AssignedUsers = _context.AssignedTasks
                        .Where(at => at.TaskId == t.Id)
                        .Join(_context.Users, at => at.UserId, u => u.Id, (at, u) => new { u.Id, u.Name, u.Surname, u.IconPath })
                        .ToList()
                }).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var result = await _context.Tasks
        .Where(t => t.Id == id)
        .Select(t => new
        {
            t.Id,
            t.Title,
            t.Description,
            Status = t.TaskStatus.Name,
            StatusId = t.TaskStatus.Id,
            AssignedUsers = _context.AssignedTasks
                .Where(at => at.TaskId == t.Id)
                .Join(_context.Users, at => at.UserId, u => u.Id, (at, u) => new { u.Id, u.Name, u.Surname, u.IconPath })
                .ToList()
        })
        .FirstOrDefaultAsync();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPut("update_task_status")]
        public async Task<IActionResult> UpdateTaskStatus([FromBody] Dto.Tasks.UpdateTaskStatusDto updateTaskStatusDto)
        {
            var task = await _context.Tasks.FindAsync(updateTaskStatusDto.TaskId);
            if (task == null)
            {
                return NotFound();
            }

            task.TaskStatusId = updateTaskStatusDto.StatusId;
            await _context.SaveChangesAsync();

            return Ok(task);
        }

    }


}