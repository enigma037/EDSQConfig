using EDSQConfig.Application.Common.Interface;
using EDSQConfig.Common.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDSQConfig.Application.ApplicationConfigurations.Queries
{
    public class GetByIdAppConfigHandler : IRequestHandler<GetByIdAppConfigQuery, GetByIdAppConfigResponse>
    {
        private readonly IEDSConfigDbContext _dbContext;

        public GetByIdAppConfigHandler(IEDSConfigDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetByIdAppConfigResponse> Handle(GetByIdAppConfigQuery request, CancellationToken cancellationToken)
        {
            var dbAppConfig = await _dbContext.ApplicationConfigurations.FindAsync(request.Id);
            if (dbAppConfig == null)
            {
                throw new NotFoundException("Invalid ApplicationConfiguration id.");
            }

            var response = new GetByIdAppConfigResponse
            {
                Id = dbAppConfig.Id,
                OrganizationId = dbAppConfig.OrganizationId,
                ConfigurationDefinitionId = dbAppConfig.ConfigurationDefinitionId,
                ConfigurationValue = dbAppConfig.ConfigurationValue,
                ApplicationCode = dbAppConfig.ApplicationCode,
            };
            return response;
        }
    }
}
