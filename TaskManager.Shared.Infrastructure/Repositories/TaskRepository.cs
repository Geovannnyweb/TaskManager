using Microsoft.EntityFrameworkCore;
using TaskManager.Shared.Infrastructure.DBContext;
using TaskManager.Task.Application.Services.Interfaces;

namespace TaskManager.Shared.Infrastructure.Repositories
{
    public class TaskRepository<T> : ITaskRepository<T> where T : class
    {
        private readonly TaskManagerDBContext _taskManagerDbContext;

        public TaskRepository(TaskManagerDBContext taskManagerDbContext)
        {
            _taskManagerDbContext = taskManagerDbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _taskManagerDbContext.Set<T>().ToListAsync();

        public async Task<T> GetById(Guid id)
        {
            return (await _taskManagerDbContext.Set<T>().FindAsync(id))!;
        }

        public async Task<T> SaveAsync(T entity)
        {
            _taskManagerDbContext.Set<T>().Add(entity);
            await _taskManagerDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(Guid id, T entity)
        {
            var currentEntity = await _taskManagerDbContext.Set<T>().FindAsync(id);
            if (currentEntity != null)
            {
                _taskManagerDbContext.Set<T>().Update(currentEntity);
                await _taskManagerDbContext.SaveChangesAsync();
            }
            return currentEntity!;
        }
        public async Task<T> DeleteAsync(Guid id)
        {
            var existingEntity = await _taskManagerDbContext.Set<T>().FindAsync(id);
            if (existingEntity != null)
            {
                _taskManagerDbContext.Set<T>().Remove(existingEntity);
                await _taskManagerDbContext.SaveChangesAsync();
            }
            return existingEntity!;
        }

    }
}
