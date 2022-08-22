using EDSQConfig.UI.Models;

namespace EDSQConfig.UI.Interfaces
{
    public interface IConfigurationDefinitionService
    {
        Task<List<ConfigurationDefinition>> ListAsync(CancellationToken cancellationToken);
        Task<string> CreateAsync(ConfigurationDefinition definition,CancellationToken cancellationToken);
        
    }
}
