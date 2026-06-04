using Application.FluentValidation;
using FluentValidation;

namespace Presentation.ConfigurationExtensions
{
    public static class FluentValidationExtension
    {
        public static IServiceCollection AddFluentValidationExtension(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<TodoValidator>();
            return services;
        }
    }
}
