using Microsoft.EntityFrameworkCore;
using TaskManager.User.Application.Services.Interfaces;
using TaskManager.User.Infrastructure.Services;

namespace TaskManager.User.Infrastructure.DBContext.Repositories
{
    public class UserRepository<T> : IRepository<T> where T : class
    {
        private readonly UserDbContext _userDbContext;
        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => await _userDbContext.Set<T>().ToListAsync();

        public async Task<T> GetById(Guid id) => (await _userDbContext.Set<T>().FindAsync(id))!;

        public async Task<T> SaveAsync(T entity)
        {
           _userDbContext.Set<T>().Add(entity);
            await _userDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(Guid id, T entity)
        {
            var existingEntity = await _userDbContext.Set<T>().FindAsync(id);
            if(existingEntity != null)
            {
                _userDbContext.Update(existingEntity);
                await _userDbContext.SaveChangesAsync();
            }
            return existingEntity!;
        }
        public async Task<T> DeleteAsync(Guid id)
        {
            var entity = await _userDbContext.Set<T>().FindAsync(id);
            if(entity != null)
            {
                _userDbContext.Set<T>().Remove(entity);
                await _userDbContext.SaveChangesAsync();
            }
            return entity!;
        }
    }
}

