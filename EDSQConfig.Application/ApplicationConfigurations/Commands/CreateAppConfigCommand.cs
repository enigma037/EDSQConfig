using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
