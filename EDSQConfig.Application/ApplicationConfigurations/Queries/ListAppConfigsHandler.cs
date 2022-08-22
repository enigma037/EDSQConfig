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
                                              .Where(w => (string.IsNullOrEmpty(request.ApplicationCode) || request.ApplicationCode.Length < 2 || w.ApplicationCode.ToLower().Contains(request.ApplicationCode.ToLower())) &&
                                              (string.IsNullOrEmpty(request.ConfigurationValue) || request.ConfigurationValue.Length < 2 || w.ConfigurationValue.ToLower().Contains(request.ConfigurationValue.ToLower())))
                                              .Select(s => new ListAppConfigsResponse { }).ToListAsync(cancellationToken);

            return listResult;
        }
    }

}


