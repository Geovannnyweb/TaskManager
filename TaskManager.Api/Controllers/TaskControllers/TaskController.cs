using Microsoft.AspNetCore.Mvc;
using TaskManager.Task.Application.Services.Interfaces;
using TaskEntity = TaskManager.Task.Domain.Models.Task;

namespace TaskManager.Api.Controllers.TaskControllers
{
    [Route("task/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices _taskServices;

        public TaskController(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskEntity>>> Get() =>  Ok(await _taskServices.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskEntity>> GetTaskById(Guid id) => Ok(await _taskServices.GetTaskByIdAsync(id));

        [HttpPut]
        public async Task<ActionResult<TaskEntity>> UpdateTaskAsync(Guid id, [FromBody] TaskEntity taskEntity)
        {
            await _taskServices.UpdateAsync(id, taskEntity);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TaskEntity>> UpdateStatusTaskAsync(Guid id, [FromBody] TaskEntity taskEntity)
        {
            await _taskServices.UpdateStatusAsync(id, taskEntity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskEntity>> DeleteTaskAsync(Guid id)
        {
            await _taskServices.DeleteAsync(id);
            return Ok();
        }


    }
}
