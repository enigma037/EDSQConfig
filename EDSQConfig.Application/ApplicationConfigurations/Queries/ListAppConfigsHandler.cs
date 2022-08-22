using EDSQConfig.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDSQConfig.Application.ApplicationConfigurations.Queries
{
    public class ListAppConfigsHandler : IRequestHandler<ListAppConfigsQuery, List<ListAppConfigsResponse>>
    {
        private readonly IEDSConfigDbContext _dbContext;

        public ListAppConfigsHandler(IEDSConfigDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ListAppConfigsResponse>> Handle(ListAppConfigsQuery request, CancellationToken cancellationToken)
        {
            var listResult = await _dbContext.ApplicationConfigurations
                                              .Select(s => new ListAppConfigsResponse {
                                                  Id= s.Id,
                                              ApplicationCode = s.ApplicationCode,
                                              ConfigurationValue = s.ConfigurationValue,
                                              ConfigurationDefinitionId = s.ConfigurationDefinitionId,
                                              OrganizationId = s.OrganizationId,
                                              
                                              }).ToListAsync(cancellationToken);

            return listResult;
        }
    }

}


