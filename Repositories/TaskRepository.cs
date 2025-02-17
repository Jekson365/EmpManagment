using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Dto.Comments;
using MyApp.Dto.TaskItems;
using MyApp.Dto.Tasks;
using MyApp.Dto.User;
using MyApp.Interfaces;
using MyApp.Models;

namespace MyApp.Repositories
{

    public class TaskRepository : ITaskRepository
    {
        public readonly ApplicationDbContext _context;
        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Tasks.Task> Create(NewTaskDto newTaskDto)
        {
            var newTask = new Models.Tasks.Task
            {
                Title = newTaskDto.Title,
                Description = newTaskDto.Description,
                EndDate = newTaskDto.EndDate.ToUniversalTime()
            };

            await _context.Tasks.AddAsync(newTask);
            await _context.SaveChangesAsync();

            return newTask;
        }
        public async Task<TaskItemDto?> GetById(int id)
        {
            var result = await _context.Tasks
                .Where(t => t.Id == id)
               .Select(t => new TaskItemDto
               {
                   Id = t.Id,
                   Title = t.Title,
                   Description = t.Description,
                   CreatedAt = t.CreatedAt,
                   EndDate = t.EndDate,
                   Status = t.TaskStatus.Name,
                   StatusId = t.TaskStatus.Id,
                   Comments = _context.Comments
                    .Where(c => c.TaskId == t.Id)
                    .Select(c => new UserCommentDto
                    {
                        Content = c.Content,
                        Id = c.Id,
                        User = _context.Users.Where(u => u.Id == c.UserId).Select(u => new CommentUserDto
                        {
                            Name = u.Name,
                            Surname = u.Surname,
                            IconPath = u.IconPath,
                        }).FirstOrDefault()
                    })
                    .ToList(),
                   AssignedUsers = _context.AssignedTasks
                       .Where(at => at.TaskId == t.Id)
                       .Join(_context.Users, at => at.UserId, u => u.Id, (at, u) => new TaskUserDto
                       {
                           Id = u.Id,
                           Name = u.Name,
                           Surname = u.Surname,
                           IconPath = u.IconPath
                       })
                       .ToList()
               }).FirstOrDefaultAsync();

            if (result == null)
            {
                return null;
            }

            return result;
        }

        public async Task<List<TaskItemDto>?> GetByStatusId(GetByStatusDto StatusDto)
        {
            var query = _context.Tasks.Select(t => new
            TaskItemDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                CreatedAt = t.CreatedAt,
                EndDate = t.EndDate,
                Status = t.TaskStatus.Name,
                StatusId = t.TaskStatus.Id,
                AssignedUsers = _context.AssignedTasks
                    .Where(at => at.TaskId == t.Id)
                    .Join(_context.Users, at => at.UserId, u => u.Id, (at, u) => new TaskUserDto
                    {
                        Id = u.Id,
                        Name = u.Name,
                        Surname = u.Surname,
                        IconPath = u.IconPath
                    }
                    )
                    .ToList()
            });

            if (StatusDto?.StatusId != null)
            {
                query = query.Where(t => t.StatusId == StatusDto.StatusId);
            }

            var result = await query.ToListAsync();
            return result;
        }

        public async Task<List<TaskItemDto>> GetByUserId(int UserId)
        {
            var result = await _context.Tasks
            .Where(t => _context.AssignedTasks.Any(at => at.TaskId == t.Id && at.UserId == UserId))
            .Select(t => new
          TaskItemDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                CreatedAt = t.CreatedAt,
                EndDate = t.EndDate,
                Status = t.TaskStatus.Name,
                StatusId = t.TaskStatus.Id,
                AssignedUsers = _context.AssignedTasks
                   .Where(at => at.TaskId == t.Id)
                  .Join(_context.Users, at => at.UserId, u => u.Id, (at, u) => new TaskUserDto
                  {
                      Id = u.Id,
                      Name = u.Name,
                      Surname = u.Surname,
                      IconPath = u.IconPath
                  }
                  )
                  .ToList()
            }).ToListAsync();

            return result;
        }

        public async Task<Models.Tasks.Task?> UpdateDueDate(UpdateDueDateDto updateDueDateDto)
        {
            var task = await _context.Tasks.FindAsync(updateDueDateDto.TaskId);
            if (task == null)
            {
                return null;
            }

            task.EndDate = updateDueDateDto.EndDate.ToUniversalTime();
            await _context.SaveChangesAsync();
            return task;

        }

        public async Task<Models.Tasks.Task?> UpdateTaskStatus(UpdateTaskStatusDto updateTaskStatusDto)
        {
            var task = await _context.Tasks.FindAsync(updateTaskStatusDto.TaskId);
            if (task == null)
            {
                return null;
            }

            task.TaskStatusId = updateTaskStatusDto.StatusId;
            await _context.SaveChangesAsync();
            return task;
        }

        async Task<List<TaskItemDto>> ITaskRepository.GetAll()
        {
            var result = await _context.Tasks
               .Select(t => new TaskItemDto
               {
                   Id = t.Id,
                   Title = t.Title,
                   Description = t.Description,
                   CreatedAt = t.CreatedAt,
                   EndDate = t.EndDate,
                   Status = t.TaskStatus.Name,
                   StatusId = t.TaskStatus.Id,
                   AssignedUsers = _context.AssignedTasks
                       .Where(at => at.TaskId == t.Id)
                       .Join(_context.Users, at => at.UserId, u => u.Id, (at, u) => new TaskUserDto
                       {
                           Id = u.Id,
                           Name = u.Name,
                           Surname = u.Surname,
                           IconPath = u.IconPath
                       })
                       .ToList()
               }).ToListAsync();
            return result;
        }
    }
}