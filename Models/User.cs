namespace task.Models;

public class User: BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public List<TaskItem>? Tasks { get; set; } = [];
}