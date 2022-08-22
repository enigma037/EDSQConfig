using EDSQConfig.UI.Models;

namespace EDSQConfig.UI.Interfaces
{
    public interface IApplicationConfigurationService
    {
        Task<List<SelectItem>> GetOrganizationsSelectItemsAsync(CancellationToken cancellationToken);
        Task<List<SelectItem>> GetConfigurationDefinitationSelectItemsAsync(CancellationToken cancellationToken);
        Task<List<ApplicationConfiguration>> ListAsync(CancellationToken cancellationToken);
        Task<ApplicationConfiguration> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<string> CreateAsync(ApplicationConfiguration applicationConfiguration, CancellationToken cancellationToken);
        Task<string> UpdateAsync(int id, ApplicationConfiguration applicationConfiguration, CancellationToken cancellationToken);
    }
}
