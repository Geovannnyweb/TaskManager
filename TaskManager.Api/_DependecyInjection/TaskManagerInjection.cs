using TaskManager.Task.Application.Services;
using TaskManager.Task.Application.Services.Interfaces;
using TaskManager.User.Application.Services;
using TaskManager.User.Application.Services.Interfaces;

namespace TaskManager.Api._DependecyInjection
{
    public static class TaskManagerInjection
    {
        public static void InjectTaskManager(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<ITaskServices, TaskServices>();
        }

    }
}
