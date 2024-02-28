using UserEntity = TaskManager.User.Domain.Models.User;

namespace TaskManager.User.Application.Services.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<UserEntity>> GetAllAsync();
        Task<UserEntity> GetByIdAsync(Guid id);
        Task<UserEntity> SaveAsync(UserEntity user);
        Task<UserEntity> UpdateAsync(Guid id, UserEntity user);
        Task<UserEntity> DeleteAsync(Guid id);
    }
}
