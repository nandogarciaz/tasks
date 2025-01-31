using Microsoft.AspNetCore.Mvc;
using task.DTOs;
using task.Service;

namespace task.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TasksDto>>> GetTasks()
    =>  Ok(await _taskService.GetTasksAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<TasksDto>> GetTaskById(int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);
        if (task == null) return NotFound();
        return Ok(task);
    }

    [HttpPost]
    public async Task<ActionResult<TasksDto>> CreateTask(TasksDto TasksDto)
    {
        var task = await _taskService.CreateTaskAsync(TasksDto);
        return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, TasksDto TasksDto)
    {
        var updated = await _taskService.UpdateTaskAsync(id, TasksDto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var deleted = await _taskService.DeleteTaskAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
