using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Dto.TaskItems;
using MyApp.Dto.Tasks;
using MyApp.Interfaces;
using MyApp.Models.Tasks;

namespace MyApp.Controllers.Tasks
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepo;
        public TaskController(ITaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
        }
        [Authorize(Roles = "superadmin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewTaskDto newTaskDto)
        {
            var result = await _taskRepo.Create(newTaskDto);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _taskRepo.GetAll();
            return Ok(result);
        }
        [HttpGet("get_task_by_user/{UserId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] int UserId) {
            var result = await _taskRepo.GetByUserId(UserId);

            return Ok(result);   
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var result = await _taskRepo.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("update_task_status")]
        public async Task<IActionResult> UpdateTaskStatus([FromBody] Dto.Tasks.UpdateTaskStatusDto updateTaskStatusDto)
        {
            var result = await _taskRepo.UpdateTaskStatus(updateTaskStatusDto);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("get_tasks_by_status")]
        public async Task<IActionResult> GetByStatusId([FromBody] GetByStatusDto StatusDto)
        {
            var result = await _taskRepo.GetByStatusId(StatusDto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("update_due_date")]
        public async Task<IActionResult> UpdateDueDate([FromBody] UpdateDueDateDto UpdateDueDate)
        {
            var result = _taskRepo.UpdateDueDate(UpdateDueDate);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }


}