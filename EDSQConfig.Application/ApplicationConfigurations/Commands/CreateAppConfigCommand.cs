using MediatR;

namespace EDSQConfig.Application.ApplicationConfigurations.Commands
{
    public class CreateAppConfigCommand :IRequest
    {
        public string ApplicationCode { get; set; }
        public int OrganizationId { get; set; }
        public int ConfigurationDefinitionId { get; set; }
        public string ConfigurationValue { get; set; }
    }
}
