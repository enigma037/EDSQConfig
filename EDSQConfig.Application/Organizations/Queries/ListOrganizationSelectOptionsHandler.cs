using EDSQConfig.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EDSQConfig.Application.Organizations.Queries
{
    public class ListOrganizationSelectOptionsHandler : IRequestHandler<ListOrganizationSelectOptionsQuery, List<ListOrganizationSelectOptionsResponse>>
    {
        private readonly IEDSConfigDbContext _dbContext;
        public ListOrganizationSelectOptionsHandler(IEDSConfigDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ListOrganizationSelectOptionsResponse>> Handle(ListOrganizationSelectOptionsQuery request, CancellationToken cancellationToken)
        {
            var response = await _dbContext.Organizations.OrderBy(o => o.Name)
                                        .Select(s => new ListOrganizationSelectOptionsResponse
                                        {
                                            Id = s.OrganizationId,
                                            Name = s.ClientAlphaID
                                        }).ToListAsync(cancellationToken);

            return response;
        }
    }
}
