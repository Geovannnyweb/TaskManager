using TaskEntity = TaskManager.Task.Domain.Models.Task;

namespace TaskManager.Task.Application.Services.Interfaces
{
    public interface ITaskServices
    {
        Task<IEnumerable<TaskEntity>> GetAllAsync();
        Task<TaskEntity> GetTaskByIdAsync(Guid id);
        Task<TaskEntity> SaveAsync(TaskEntity task);
        Task<TaskEntity> UpdateAsync(Guid id, TaskEntity task);
        Task<TaskEntity> UpdateStatusAsync(Guid id, TaskEntity task);   
        Task<TaskEntity> DeleteAsync(Guid id);
    }
}
