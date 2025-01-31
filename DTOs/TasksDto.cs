using task.Models;

namespace task.DTOs;

public class TasksDto: BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Deadline { get; set;}= DateTime.UtcNow.AddDays(1);
    public DateTime Created { get; set;} = DateTime.UtcNow;
    public int UserId { get; set; }

    public UserDto? User { get; set; }
}
