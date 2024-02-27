using Microsoft.EntityFrameworkCore;
using TaskEntity = TaskManager.Task.Domain.Models.Task;

namespace TaskManager.Task.Infrastructure.DBContext
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions options) : base(options) { }
        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskEntity>(task =>
            {
                task.ToTable("Tasks");
                task.HasKey(task => task.TaskId);
                task.HasOne(p => p.Users).WithMany().HasForeignKey(task => task.UserId).OnDelete(DeleteBehavior.Cascade);
                task.Property(task => task.Title).IsRequired().HasMaxLength(100);
                task.Property(task => task.Description).IsRequired(false).HasMaxLength(200);
                task.Property(task => task.Status).IsRequired();
                task.Property(task => task.CreatedDate).IsRequired();
            });

        }
    }

}
