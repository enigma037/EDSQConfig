using MediatR;
using System.Collections.Generic;

namespace EDSQConfig.Application.Organizations.Queries
{
    public class ListOrganizationSelectOptionsQuery : IRequest<List<ListOrganizationSelectOptionsResponse>>
    {
    }
}
