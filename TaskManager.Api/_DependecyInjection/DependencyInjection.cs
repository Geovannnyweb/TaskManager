namespace TaskManager.Api._DependecyInjection
{
    public static class DependencyInjection
    {
        public static void Inject(this WebApplicationBuilder builder)
        {
            TaskManagerInjection.InjectTaskManager(builder);
            ServicesInjection.InnjectServices(builder);
        }
    }
}
