using EDSQConfig.UI.Models;

namespace EDSQConfig.UI.Interfaces
{
    public interface IApplicationConfigurationService
    {
        Task<List<SelectItem>> GetOrganizationsSelectItemsAsync(CancellationToken cancellationToken);
    }
}
