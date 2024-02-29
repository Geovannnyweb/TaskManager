using TaskManager.User.Application.Services.Interfaces;
using UserEntity = TaskManager.User.Domain.Models.User;

namespace TaskManager.User.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository<UserEntity> _userRepository;
        public UserServices(IUserRepository<UserEntity> userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserEntity>> GetAllAsync() => await _userRepository.GetAllAsync();

        public async Task<UserEntity> GetByIdAsync(Guid id) => await _userRepository.GetById(id);
         
        public async Task<UserEntity> SaveAsync(UserEntity user) => await _userRepository.SaveAsync(user);

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

                await _userRepository.UpdateAsync(id, user);
            }
            return currentUser!;
        }

        public async Task<UserEntity> DeleteAsync(Guid id)
        {
          var existingUser =  await  _userRepository.GetById(id);
            if (existingUser != null)
                await _userRepository.DeleteAsync(id);
            return existingUser!;
        }

    }
}
