using Microsoft.EntityFrameworkCore;
using UserEntity =  TaskManager.User.Domain.Models.User;

namespace TaskManager.User.Infrastructure.Services
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options) {}
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
