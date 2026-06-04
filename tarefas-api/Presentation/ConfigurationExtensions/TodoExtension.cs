using Application.InterfacesApp;
using Application.ServicesApp;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Domain.Services;
using Infra.Repositories;

namespace Presentation.ConfigurationExtensions
{
    public static class TodoExtension
    {
        public static IServiceCollection AddTodoExtension(this IServiceCollection services)
        {
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddTransient<ITodoService, TodoService>();
            services.AddTransient<ITodoServiceApp, TodoServiceApp>();
            return services;
        }
    }
}
