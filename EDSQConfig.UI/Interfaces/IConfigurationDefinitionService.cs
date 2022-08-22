using EDSQConfig.UI.Models;

namespace EDSQConfig.UI.Interfaces
{
    public interface IConfigurationDefinitionService
    {
        Task<List<ConfigurationDefinition>> ListAsync(CancellationToken cancellationToken);
        Task<ConfigurationDefinition> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<string> CreateAsync(ConfigurationDefinition definition,CancellationToken cancellationToken);
        Task<string> UpdateAsync(int id, ConfigurationDefinition definition,CancellationToken cancellationToken);
        
    }
}
