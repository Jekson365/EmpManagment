using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Controllers.Tasks;
using MyApp.Data;

namespace MyApp.Controllers.TaskStatus
{
    [ApiController]
    [Route("api/task_status")]
    public class TaskStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TaskStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var taskStatuses = await _context.TaskStatuses.ToListAsync();

            return Ok(taskStatuses);
        }
    }
}