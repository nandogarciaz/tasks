using Microsoft.EntityFrameworkCore;
using task.Data;
using task.DTOs;
using task.Models;

namespace task.Service;

public class TaskService : ITaskService
{
    private readonly AppDbContext _context;

    public TaskService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TasksDto>> GetTasksAsync()
    {
        return await _context.Tasks
            .Include(o => o.User)
            .Select(t => new TasksDto
            {
                Id = t.Id,
                Description = t.Description,
                Deadline = t.Deadline,
                Created = t.Created,
                IsCompleted = t.IsCompleted,
                UserId = t.UserId,
                User = new UserDto {
                    Id = t.UserId,
                    Name = t.User.Name
                }
            })
            .ToListAsync();
    }

    public async Task<TasksDto?> GetTaskByIdAsync(int id)
    {
        var task = await _context.Tasks
            .Include(o => o.User)
            .FirstAsync(x => x.Id == id);
            
        if (task == null) return null;

        return new TasksDto
        {
            Id = task.Id,
            Description = task.Description,
            Deadline = task.Deadline,
            Created = task.Created,
            IsCompleted = task.IsCompleted,
            UserId = task.UserId,
            User = new UserDto {
                Id = task.UserId,
                Name = task.User.Name
            }
        };
    }

    public async Task<TasksDto> CreateTaskAsync(TasksDto tasksDto)
    {
        var task = new TaskItem
        {
            Description = tasksDto.Description,
            Deadline = tasksDto.Deadline,
            Created = DateTime.UtcNow,
            IsCompleted = tasksDto.IsCompleted,
            UserId = tasksDto.UserId,
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return new TasksDto
        {
            Id = task.Id,
            Description = task.Description,
            Deadline = task.Deadline,
            Created = task.Created,
            IsCompleted = tasksDto.IsCompleted,
            UserId = task.UserId
        };
    }

    public async Task<bool> UpdateTaskAsync(int id, TasksDto tasksDto)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return false;

        task.Description = tasksDto.Description;
        task.Deadline = tasksDto.Deadline;
        task.UserId = tasksDto.UserId;
        task.IsCompleted = tasksDto.IsCompleted;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return false;

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }
}
