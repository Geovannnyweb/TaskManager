using TaskManager.Task.Application.Services.Interfaces;
using TaskManager.Shared.Infrastructure.Repositories;
using TaskManager.User.Application.Services.Interfaces;
using TaskEntity = TaskManager.Task.Domain.Models.Task;
using UserEntity = TaskManager.User.Domain.Models.User;
using TaskManager.Shared.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Api._DependecyInjection
{
    public static class ServicesInjection
    {
        public static void InnjectServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DbContext, TaskManagerDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("cnTaskManager"),
                b => b.MigrationsAssembly("TaskManager.Api")), ServiceLifetime.Transient);
            builder.Services.AddScoped<IUserRepository<UserEntity>,
                UserRepository<UserEntity>>();
            builder.Services.AddScoped<ITaskRepository<TaskEntity>,
                TaskRepository<TaskEntity>>();
        }
    }
}
