using Microsoft.Extensions.DependencyInjection;

namespace ProduceReport.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            services.AddScoped<IEntityService<Workshop>, WorkshopService>();
                
            return services;
        }
    }
}
