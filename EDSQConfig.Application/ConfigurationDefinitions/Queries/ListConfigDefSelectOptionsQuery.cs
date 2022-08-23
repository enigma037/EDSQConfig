using MediatR;
using System.Collections.Generic;

namespace EDSQConfig.Application.ConfigurationDefinitions.Queries
{
    public class ListConfigDefSelectOptionsQuery : IRequest<List<ListConfigDefSelectOptionsResponse>>
    {
    }
}
