using TaskManager.User.Application.Services.Interfaces;
using UserEntity = TaskManager.User.Domain.Models.User;

namespace TaskManager.User.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IRepository<UserEntity> _userRepository;
        public UserServices(IRepository<UserEntity> userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
           return await _userRepository.GetAllAsync();
        }

        public void SaveAsync(UserEntity user)
        {
            _userRepository.SaveAsync(user);
        }

        public async Task<UserEntity> UpdateAsync(Guid id, UserEntity user)
        {
            var currentUser = await _userRepository.GetById(id);
            if (currentUser != null)
            {
               currentUser.Name = user.Name;
                currentUser.Lastname = user.Lastname;
                currentUser.Phone = user.Phone;
                currentUser.Password = user.Password;
                currentUser.Email = user.Email;

                await _userRepository.UpdateAsync(user);
            }
            return currentUser!;
        }

        public void DeleteAsync(Guid id)
        {
            _userRepository.GetById(id);
            _userRepository.DeleteAsync(id);
        }

    }
}
