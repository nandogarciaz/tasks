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
            .Select(t => new TasksDto
            {
                Id = t.Id,
                Description = t.Description,
                Deadline = t.Deadline,
                Created = t.Created,
                UserId = t.UserId
            })
            .ToListAsync();
    }

    public async Task<TasksDto?> GetTaskByIdAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return null;

        return new TasksDto
        {
            Id = task.Id,
            Description = task.Description,
            Deadline = task.Deadline,
            Created = task.Created,
            UserId = task.UserId
        };
    }

    public async Task<TasksDto> CreateTaskAsync(TasksDto TasksDto)
    {
        var task = new TaskItem
        {
            Description = TasksDto.Description,
            Deadline = TasksDto.Deadline,
            Created = DateTime.UtcNow,
            UserId = TasksDto.UserId
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return new TasksDto
        {
            Id = task.Id,
            Description = task.Description,
            Deadline = task.Deadline,
            Created = task.Created,
            UserId = task.UserId
        };
    }

    public async Task<bool> UpdateTaskAsync(int id, TasksDto TasksDto)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return false;

        task.Description = TasksDto.Description;
        task.Deadline = TasksDto.Deadline;
        task.UserId = TasksDto.UserId;

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
