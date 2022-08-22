using EDSQConfig.Domain.Entities.EDSConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace EDSQConfig.Application.Common.Interface
{
    public interface IEDSConfigDbContext
    {
        DbSet<ApplicationConfiguration> ApplicationConfigurations { get; set; }
        DbSet<ConfigurationDefinition> ConfigurationDefinitions { get; set; }
        DbSet<Organization> Organizations { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
