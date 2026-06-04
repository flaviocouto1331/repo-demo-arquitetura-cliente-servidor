using Infra.Dapper;

namespace Presentation.ConfigurationExtensions
{
    public static class DapperExtension
    {
        public static IServiceCollection AddDapperExtension(this IServiceCollection services) 
        {
            services.AddScoped<DapperContext>();
            return services;
        }
    }
}
