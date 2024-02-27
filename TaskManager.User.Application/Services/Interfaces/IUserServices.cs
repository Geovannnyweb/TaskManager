using UserEntity = TaskManager.User.Domain.Models.User;

namespace TaskManager.User.Application.Services.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<UserEntity>> GetAllAsync();
        void SaveAsync(UserEntity user);
        Task<UserEntity> UpdateAsync(Guid id, UserEntity user);
        void DeleteAsync(Guid id);
    }
}
