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
    }
}
