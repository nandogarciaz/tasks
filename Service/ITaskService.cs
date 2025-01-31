using task.DTOs;

namespace task.Service;

public interface ITaskService 
{
    Task<IEnumerable<TasksDto>> GetTasksAsync();
    Task<TasksDto?> GetTaskByIdAsync(int id);
    Task<TasksDto> CreateTaskAsync(TasksDto TasksDto);
    Task<bool> UpdateTaskAsync(int id, TasksDto TasksDto);
    Task<bool> DeleteTaskAsync(int id);
}
