using Microsoft.Extensions.DependencyInjection;
using ProduceReport.Core.Services;

namespace ProduceReport.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            services.AddScoped<IEntityService<Workshop>, WorkshopService>();
            services.AddScoped<IEntityService<Workshift>, WorkshiftService>();

            return services;
        }
    }
}
