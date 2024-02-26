using Microsoft.EntityFrameworkCore;
using TaskEntity = TaskManager.Task.Domain.Models.Task;

namespace TaskManager.Task.Infrastructure.Services
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }
    }


}
