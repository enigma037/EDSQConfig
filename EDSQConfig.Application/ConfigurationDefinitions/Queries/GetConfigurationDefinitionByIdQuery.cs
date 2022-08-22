using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDSQConfig.Application.ConfigurationDefinitions.Queries
{
    public class GetConfigurationDefinitionByIdQuery : IRequest<GetConfigurationDefinitionByIdResponse>
    {
        public int Id { get; set; }
    }
}
