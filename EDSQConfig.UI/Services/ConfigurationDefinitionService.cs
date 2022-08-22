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

        public async Task<ConfigurationDefinition> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var response = await _apiService.GetAsync<ConfigurationDefinition>($"/configurationdefinitions/{id}", cancellationToken: cancellationToken);
            return response;
        }

        public async Task<List<ConfigurationDefinition>> ListAsync(CancellationToken cancellationToken)
        {
            var response = await _apiService.GetAsync<List<ConfigurationDefinition>>("/configurationdefinitions", cancellationToken: cancellationToken);
            return response;
        }

        public async Task<string> UpdateAsync(int id, ConfigurationDefinition definition, CancellationToken cancellationToken)
        {
            var response = await _apiService.PutAsync($"/configurationdefinitions/{id}", definition, cancellationToken: cancellationToken);
            return response;
        }
    }
}
