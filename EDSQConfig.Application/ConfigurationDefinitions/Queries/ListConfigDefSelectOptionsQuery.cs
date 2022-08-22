using MediatR;
using System.Collections.Generic;

namespace EDSQConfig.Application.Organizations.Queries
{
    public class ListConfigDefSelectOptionsQuery : IRequest<List<ListConfigDefSelectOptionsResponse>>
    {
    }
}
