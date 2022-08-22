using EDSQConfig.Application.Common.Interface;
using EDSQConfig.Domain.Entities.EDSConfig;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace EDSQConfig.Infrastructure.Persistence
{
    public class EDSConfigDbContext : DbContext, IEDSConfigDbContext
    {
        
        public DbSet<ApplicationConfiguration> ApplicationConfigurations { get; set; }
        public DbSet<ConfigurationDefinition> ConfigurationDefinitions { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public EDSConfigDbContext(DbContextOptions<EDSConfigDbContext> options) :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
