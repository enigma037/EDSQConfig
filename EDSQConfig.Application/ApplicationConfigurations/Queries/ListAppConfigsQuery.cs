using MediatR;
using System.Collections.Generic;

namespace EDSQConfig.Application.ApplicationConfigurations.Queries
{
    public class ListAppConfigsQuery :  IRequest<List<ListAppConfigsResponse>>
    {
        public string ApplicationCode { get; set; }
        public string ConfigurationValue { get; set; }
    }
}
