using Microsoft.AspNetCore.Mvc;
using TaskManager.User.Application.Services.Interfaces;
using UserEntity = TaskManager.User.Domain.Models.User;

namespace TaskManager.Api.Controllers.UserControllers
{
    [Route("user/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserEntity>>> GetAllUserAsync() =>
            Ok(await _userServices.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<UserEntity>> GetUserByIdAsync(Guid id) => 
            Ok(await _userServices.GetByIdAsync(id));

        [HttpPost]
        public async Task<ActionResult<UserEntity>> SaveUserAsync([FromBody] UserEntity userEntity)
        {
            await _userServices.SaveAsync(userEntity);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserEntity>> UpdateUserAsync(Guid id,[FromBody] UserEntity userEntity) 
        { 
            await _userServices.UpdateAsync(id, userEntity);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserEntity>> DeleteUserAsync(Guid id)
        {
            await _userServices.DeleteAsync(id);
            return Ok();
        }

    }
}
