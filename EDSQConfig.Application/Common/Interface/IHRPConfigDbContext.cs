using EDSQConfig.Domain.Entities.HRPConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace EDSQConfig.Application.Common.Interface
{
    public interface IHRPConfigDbContext
    {
        DbSet<SSIS_Config> SSIS_Configs { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
