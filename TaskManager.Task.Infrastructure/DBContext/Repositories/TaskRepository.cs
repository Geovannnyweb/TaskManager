using Microsoft.EntityFrameworkCore;
using TaskManager.Task.Application.Services.Interfaces;

namespace TaskManager.Task.Infrastructure.DBContext.Repositories
{
    public class TaskRepository<T> : IRepository<T> where T : class
    {
        private readonly TaskDbContext _taskDbContext;

        public TaskRepository(TaskDbContext taskDbContext)
        {
            _taskDbContext = taskDbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => await _taskDbContext.Set<T>().ToListAsync();

        public async Task<T> GetById(Guid id)
        {
            return (await _taskDbContext.Set<T>().FindAsync())!;
        }

        public async Task<T> SaveAsync(T entity)
        {
            _taskDbContext.Set<T>().Add(entity);
            await _taskDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(Guid id, T entity)
        {
            var currentEntity = await _taskDbContext.Set<T>().FindAsync(id);
            if (currentEntity != null)
            {
                _taskDbContext.Set<T>().Update(entity);
                await _taskDbContext.SaveChangesAsync();
            }
            return currentEntity!;
        }
        public async Task<T> DeleteAsync(Guid id)
        {
            var existingEntity = await _taskDbContext.Set<T>().FindAsync(id);
            if (existingEntity != null)
            {
                _taskDbContext.Set<T>().Remove(existingEntity);
                await _taskDbContext.SaveChangesAsync();
            }
            return existingEntity!;
        }

    }
}
