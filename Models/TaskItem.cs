using System.ComponentModel.DataAnnotations.Schema;

namespace task.Models;
public class TaskItem: BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Deadline { get; set;}
    public DateTime Created { get; set;} = DateTime.UtcNow;
    public bool IsCompleted { get; set; } = false;

    [ForeignKey("User")]
    public int UserId { get; set; }
    public User? User { get; set; }
}