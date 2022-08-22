using EDSQConfig.Application.Common.Interface;
using EDSQConfig.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDSQConfig.Application.ConfigurationDefinitions.Queries
{
    public class GetConfigurationDefinitionByIdHandler : IRequestHandler<GetConfigurationDefinitionByIdQuery, GetConfigurationDefinitionByIdResponse>
    {
        private readonly IEDSConfigDbContext _dbContext;
        public GetConfigurationDefinitionByIdHandler(IEDSConfigDbContext dbContext)
        { 
            _dbContext = dbContext;
        }

        public async Task<GetConfigurationDefinitionByIdResponse> Handle(GetConfigurationDefinitionByIdQuery request, CancellationToken cancellationToken)
        {
            var dbConfigDef = await _dbContext.ConfigurationDefinitions.FindAsync(request.Id);
            if (dbConfigDef == null)
            {
                throw new NotFoundException("Invalid ConfigurationDefinition id.");
            }

            var response = new GetConfigurationDefinitionByIdResponse
            {
                Id = dbConfigDef.Id,
                ConfigurationType = dbConfigDef.ConfigurationType,
                ConfigurationDescription = dbConfigDef.ConfigurationDescription
            };
            return response;
        }
    }
}
