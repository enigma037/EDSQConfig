using EDSQConfig.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EDSQConfig.Application.Organizations.Queries
{
    public class ListOrganizationsHandler : IRequestHandler<ListOrganizationsQuery, List<ListOrganizationsResponse>>
    {
        private readonly IEDSConfigDbContext _dbContext;
        public ListOrganizationsHandler(IEDSConfigDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ListOrganizationsResponse>> Handle(ListOrganizationsQuery request, CancellationToken cancellationToken)
        {

            var listResult = await _dbContext.Organizations.Select(s => new ListOrganizationsResponse
            {
                OrganizationId = s.OrganizationId,
                Name = s.Name,
                ClientAlphaID = s.ClientAlphaID
                ,
            }).ToListAsync(cancellationToken);
            return listResult;
        }
    }
}
