using System.ComponentModel.DataAnnotations;

namespace task.Models;
public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}