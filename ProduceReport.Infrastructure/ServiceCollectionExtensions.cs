using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProduceReport.Core;
using ProduceReport.Infrastructure.Repositories;

namespace ProduceReport.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DbContext, AppDbContext>()
                .AddScoped<IRepository<Workshift>, EfRepository<Workshift>>()
                .AddScoped<IRepository<Workshop>, EfRepository<Workshop>>()
                .AddDbContext<AppDbContext>(options =>
                {
                    options.UseLazyLoadingProxies();
                    options.UseSqlite(configuration.GetConnectionString("DataContext"));
                });

            return services;
        }
    }
}
