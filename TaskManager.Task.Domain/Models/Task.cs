using UserEntity =  TaskManager.User.Domain.Models.User;

namespace TaskManager.Task.Domain.Models
{
    public class Task
    {
        public Guid TaskId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public TaskStatus Status { get; set; }
        public Guid UserId { get; set; }
        public UserEntity? Users { get; set; }
    }
}
