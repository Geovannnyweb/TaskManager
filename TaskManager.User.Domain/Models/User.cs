using TaskManager.User.Domain.Enums;

namespace TaskManager.User.Domain.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Phone {  get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public Role Role { get; set; }
        public ICollection<Task>? Tasks { get; set; }

    }
}
