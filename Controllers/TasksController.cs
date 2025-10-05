using Microsoft.AspNetCore.Mvc;
using ProjectTracker.API.Models;
using ProjectTracker.API.Services;

namespace ProjectTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<List<TaskItem>> Get() =>
            await _taskService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<TaskItem>> Get(string id)
        {
            var task = await _taskService.GetAsync(id);
            if (task is null)
                return NotFound();
            return task;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TaskItem newTask)
        {
            await _taskService.CreateAsync(newTask);
            return CreatedAtAction(nameof(Get), new { id = newTask.Id }, newTask);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, TaskItem updatedTask)
        {
            var existingTask = await _taskService.GetAsync(id);
            if (existingTask is null)
                return NotFound();

            updatedTask.Id = existingTask.Id;
            await _taskService.UpdateAsync(id, updatedTask);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingTask = await _taskService.GetAsync(id);
            if (existingTask is null)
                return NotFound();

            await _taskService.RemoveAsync(id);
            return NoContent();
        }
    }
}