using System.Text.Json.Serialization;
using task.Enums;
using task.Models;

namespace task.DTOs;

public class TasksDto: BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Deadline { get; set;}= DateTime.UtcNow.AddDays(1);
    public DateTime Created { get; set;} = DateTime.UtcNow;

    // Retorna o status como string automaticamente
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public EStatus Status { get; set; } = EStatus.Pendente;
    public int UserId { get; set; }

    public UserDto? User { get; set; }
}
