using TaskManager.Task.Application.Services.Interfaces;
using TaskEntity = TaskManager.Task.Domain.Models.Task;

namespace TaskManager.Task.Application.Services
{
    public class TaskServices : ITaskServices
    {
        private readonly IRepository<TaskEntity> _taskRepository;

        public TaskServices(IRepository<TaskEntity> taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<IEnumerable<TaskEntity>> GetAllAsync()
            => await _taskRepository.GetAllAsync();

        public async Task<TaskEntity> GetTaskByIdAsync(Guid id)
            => await _taskRepository.GetById(id);

        public async Task<TaskEntity> SaveAsync(TaskEntity task)
            => await _taskRepository.SaveAsync(task);

        public async Task<TaskEntity> UpdateAsync(Guid id, TaskEntity task)
        {
            var currentTask = await _taskRepository.GetById(id);
           if(currentTask != null)
            {
                currentTask.Title = task.Title;
                currentTask.Description = task.Description;
                currentTask.Status = task.Status;
                currentTask.CreatedDate = task.CreatedDate;

               await _taskRepository.UpdateAsync(id, task);
            }
            return currentTask!;
        }

        public async Task<TaskEntity> UpdateStatusAsync(Guid id, TaskEntity task)
        {
            var currentStatus = await _taskRepository.GetById(id);
            if(currentStatus != null)
            {
                currentStatus.Status = task.Status;
                await _taskRepository.UpdateAsync(id, task);
            }
            return currentStatus!;
        }

        public async Task<TaskEntity> DeleteAsync(Guid id)
        {
            var existingTask = await _taskRepository.GetById(id);
            if(existingTask != null) 
            await _taskRepository.DeleteAsync(id);

            return existingTask!;
        }
    }
}
