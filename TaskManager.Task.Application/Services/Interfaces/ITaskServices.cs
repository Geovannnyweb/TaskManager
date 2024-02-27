using TaskEntity = TaskManager.Task.Domain.Models.Task;

namespace TaskManager.Task.Application.Services.Interfaces
{
    public interface ITaskServices
    {
        Task<IEnumerable<TaskEntity>> GetAllAsync();
        void SaveAsync(TaskEntity task);
        Task<TaskEntity> UpdateAsync(Guid id, TaskEntity task);
        Task<TaskEntity> UpdateStatusAsync(Guid id, TaskEntity task);   
        void DeleteAsync(Guid id);
    }
}
