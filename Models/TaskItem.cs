using System.ComponentModel.DataAnnotations.Schema;
using task.Enums;

namespace task.Models;
public class TaskItem: BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Deadline { get; set;}
    public DateTime Created { get; set;} = DateTime.UtcNow;
    public EStatus Status { get; set; } = EStatus.Pendente;

    [ForeignKey("User")]
    public int UserId { get; set; }
    public User? User { get; set; }
}