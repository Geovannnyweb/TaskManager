using Microsoft.EntityFrameworkCore;
using UserEntity = TaskManager.User.Domain.Models.User;
using TaskEntity = TaskManager.Task.Domain.Models.Task;

namespace TaskManager.Shared.Infrastructure.DBContext
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<UserEntity> Users { get; set; }

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

            modelBuilder.Entity<UserEntity>(user =>
            {
                user.ToTable("Users");
                user.HasKey(user => user.UserId);
                user.Property(user => user.Name).IsRequired().HasMaxLength(80);
                user.Property(user => user.Lastname).IsRequired().HasMaxLength(80);
                user.Property(user => user.Email).IsRequired();
                user.Property(user => user.Role);
                user.Property(user => user.Password).IsRequired();
                user.Property(user => user.Phone);
            });
        }
    }
}
