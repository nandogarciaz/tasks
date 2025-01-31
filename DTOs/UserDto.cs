using task.Models;

namespace task.DTOs;

public class UserDto: BaseEntity
{
    public string Name { get; set; } = string.Empty;
}
