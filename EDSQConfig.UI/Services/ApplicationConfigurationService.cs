using EDSQConfig.UI.Interfaces;
using EDSQConfig.UI.Models;

namespace EDSQConfig.UI.Services
{
    public class ApplicationConfigurationService: IApplicationConfigurationService
    {
        private readonly IAPIService _apiService;
        public ApplicationConfigurationService(IAPIService apiService)
        {
            _apiService = apiService;
        }

        public async Task<string> CreateAsync(ApplicationConfiguration applicationConfiguration, CancellationToken cancellationToken)
        {
            var response = await _apiService.PostAsync("/applicationconfigurations", applicationConfiguration, cancellationToken:cancellationToken);
            return response;
        }

        public async Task<ApplicationConfiguration> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var response = await _apiService.GetAsync<ApplicationConfiguration>($"/applicationconfigurations/{id}", cancellationToken:cancellationToken);
            return response;
        }

        public async Task<List<SelectItem>> GetConfigurationDefinitationSelectItemsAsync(CancellationToken cancellationToken)
        {
            var response = await _apiService.GetAsync<List<SelectItem>>("/organizations/select-options", cancellationToken: cancellationToken);
            return response;
        }

        public async Task<List<SelectItem>> GetOrganizationsSelectItemsAsync(CancellationToken cancellationToken)
        {
            var response = await _apiService.GetAsync<List<SelectItem>>("/organizations", cancellationToken: cancellationToken);
            return response;
        }

        public async Task<List<ApplicationConfiguration>> ListAsync(CancellationToken cancellationToken)
        {
            var response = await _apiService.GetAsync<List<ApplicationConfiguration>>("/applicationconfigurations", cancellationToken: cancellationToken);
            return response;
        }

        public async Task<string> UpdateAsync(int id, ApplicationConfiguration applicationConfiguration, CancellationToken cancellationToken)
        {
            var response = await _apiService.PutAsync($"/applicationconfigurations/{id}", applicationConfiguration, cancellationToken:cancellationToken);
            return response;
        }
    }
}
