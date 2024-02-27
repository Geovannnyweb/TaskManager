using Microsoft.EntityFrameworkCore;
using UserEntity = TaskManager.User.Domain.Models.User;

namespace TaskManager.User.Infrastructure.Services
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {}
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
