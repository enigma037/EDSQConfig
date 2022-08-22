using EDSQConfig.UI.Interfaces;
using EDSQConfig.UI.Models;

namespace EDSQConfig.UI.Services
{
    public class ConfigurationDefinitionService : IConfigurationDefinitionService
    {
        private readonly IAPIService _apiService;
        public ConfigurationDefinitionService(IAPIService apiService)
        {
            _apiService = apiService;
        }

        public async Task<string> CreateAsync(ConfigurationDefinition definition, CancellationToken cancellationToken)
        {
            var response = await _apiService.PostAsync("/configurationdefinitions", definition,cancellationToken:cancellationToken);
            return response;
        }

        public async Task<List<ConfigurationDefinition>> ListAsync(CancellationToken cancellationToken)
        {
            var response = await _apiService.GetAsync<List<ConfigurationDefinition>>("/configurationdefinitions", cancellationToken: cancellationToken);
            return response;
        }
    }
}
