using Microsoft.EntityFrameworkCore;
using TaskManager.Shared.Infrastructure.DBContext;
using TaskManager.User.Application.Services.Interfaces;

namespace TaskManager.Shared.Infrastructure.Repositories
{
    public class UserRepository<T> : IUserRepository<T> where T : class
    {
        private readonly TaskManagerDbContext taskManagerDbContext;
        public UserRepository(TaskManagerDbContext taskManagerDbContext)
        {
            this.taskManagerDbContext = taskManagerDbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => await taskManagerDbContext.Set<T>().ToListAsync();

        public async Task<T> GetById(Guid id) => (await taskManagerDbContext.Set<T>().FindAsync(id))!;

        public async Task<T> SaveAsync(T entity)
        {
            taskManagerDbContext.Set<T>().Add(entity);
            await taskManagerDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(Guid id, T entity)
        {
            var existingEntity = await taskManagerDbContext.Set<T>().FindAsync(id);
            if (existingEntity != null)
            {
                taskManagerDbContext.Update(existingEntity);
                await taskManagerDbContext.SaveChangesAsync();
            }
            return existingEntity!;
        }
        public async Task<T> DeleteAsync(Guid id)
        {
            var entity = await taskManagerDbContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                taskManagerDbContext.Set<T>().Remove(entity);
                await taskManagerDbContext.SaveChangesAsync();
            }
            return entity!;
        }
    }
}