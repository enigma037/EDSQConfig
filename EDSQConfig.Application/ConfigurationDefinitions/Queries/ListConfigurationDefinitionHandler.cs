using EDSQConfig.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDSQConfig.Application.ConfigurationDefinitions.Queries
{
    public class ListConfigurationDefinitionHandler : IRequestHandler<ListConfigurationDefinitionQuery, List<ListConfigurationDefinitonResponse>>
    {
        private readonly IEDSConfigDbContext _dbContext;
        public ListConfigurationDefinitionHandler(IEDSConfigDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ListConfigurationDefinitonResponse>> Handle(ListConfigurationDefinitionQuery request, CancellationToken cancellationToken)
        {

            var listResult = await _dbContext.ConfigurationDefinitions.Where(w => (string.IsNullOrEmpty(request.ConfigurationType)  ||w.ConfigurationType.ToLower().Contains(request.ConfigurationType.ToLower()))).Select(s=> new ListConfigurationDefinitonResponse {
                Id = s.Id,
                ConfigurationType = s.ConfigurationType,
                ConfigurationDescription = s.ConfigurationDescription,
                DefaultValue = s.DefaultValue,
            }).ToListAsync(cancellationToken);
            return listResult;
        }
    }
}
