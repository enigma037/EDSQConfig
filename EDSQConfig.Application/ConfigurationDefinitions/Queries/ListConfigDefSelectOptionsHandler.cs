using EDSQConfig.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EDSQConfig.Application.ConfigurationDefinitions.Queries
{
    public class ListConfigDefSelectOptionsHandler : IRequestHandler<ListConfigDefSelectOptionsQuery, List<ListConfigDefSelectOptionsResponse>>
    {
        private readonly IEDSConfigDbContext _dbContext;
        public ListConfigDefSelectOptionsHandler(IEDSConfigDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ListConfigDefSelectOptionsResponse>> Handle(ListConfigDefSelectOptionsQuery request, CancellationToken cancellationToken)
        {
            var response = await _dbContext.ConfigurationDefinitions.OrderBy(o => o.ConfigurationType)
                                        .Select(s => new ListConfigDefSelectOptionsResponse
                                        {
                                            Id = s.Id,
                                            Name = s.ConfigurationType
                                        }).ToListAsync(cancellationToken);

            return response;
        }
    }
}
