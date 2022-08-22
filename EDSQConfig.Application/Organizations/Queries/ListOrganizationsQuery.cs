using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDSQConfig.Application.Organizations.Queries
{
    public class ListOrganizationsQuery : IRequest<List<ListOrganizationsResponse>>
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public string ClientAlphaID { get; set; }
    }
}
