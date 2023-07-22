using Microsoft.EntityFrameworkCore;
using ProduceReport.Core;
using System.Reflection;

namespace ProduceReport.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Workshift> Workshifts { get; private set; }

        public DbSet<Workshop> Workshops { get; private set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
