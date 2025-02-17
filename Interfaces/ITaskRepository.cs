using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyApp.Data;
using MyApp.Dto.TaskItems;
using MyApp.Dto.Tasks;
using MyApp.Models.Tasks;

namespace MyApp.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskItemDto>> GetAll();
        Task<TaskItemDto> GetById(int id);
        Task<Models.Tasks.Task> Create(NewTaskDto newTaskDto);
        Task<Models.Tasks.Task> UpdateTaskStatus(UpdateTaskStatusDto updateTaskStatusDto);
        Task<List<TaskItemDto>?> GetByStatusId(GetByStatusDto statusDto);
        Task<Models.Tasks.Task> UpdateDueDate(UpdateDueDateDto updateDueDateDto);
    }
}