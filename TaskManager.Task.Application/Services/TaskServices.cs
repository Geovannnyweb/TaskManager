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
        {
            return await _taskRepository.GetAllAsync();
        }
        public void SaveAsync(TaskEntity task)
        {
            _taskRepository.SaveAsync(task);        
        }
        public async Task<TaskEntity> UpdateAsync(Guid id, TaskEntity task)
        {
            var currentTask = await _taskRepository.GetById(id);
           if(currentTask != null)
            {
                currentTask.Title = task.Title;
                currentTask.Description = task.Description;
                currentTask.Status = task.Status;
                currentTask.CreatedDate = task.CreatedDate;

               await _taskRepository.UpdateAsync(task);
            }
            return currentTask!;
        }

        public async Task<TaskEntity> UpdateStatusAsync(Guid id, TaskEntity task)
        {
            var currentStatus = await _taskRepository.GetById(id);
            if(currentStatus != null)
            {
                currentStatus.Status = task.Status;
                await _taskRepository.UpdateAsync(task);
            }
            return currentStatus!;
        }

        public void DeleteAsync(Guid id)
        {
            _taskRepository.GetById(id);
            _taskRepository.DeleteAsync(id);
        }
    }
}
