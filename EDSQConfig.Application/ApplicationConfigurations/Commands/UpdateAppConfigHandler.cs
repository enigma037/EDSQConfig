using EDSQConfig.Application.Common.Interface;
using EDSQConfig.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDSQConfig.Application.ApplicationConfigurations.Commands
{
    public class UpdateAppConfigHandler : IRequestHandler<UpdateAppConfigCommand>
    {
        private readonly IEDSConfigDbContext _dbContext;

        public UpdateAppConfigHandler(IEDSConfigDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateAppConfigCommand request, CancellationToken cancellationToken)
        {
            var applicationConfiguration = await _dbContext.ApplicationConfigurations.FindAsync(request.Id);
            if (applicationConfiguration == null)
            {
                throw new NotFoundException("Invalid banner id.");
            }

            applicationConfiguration.ConfigurationDefinitionId = request.ConfigurationDefinitionId;
            applicationConfiguration.ConfigurationValue = request.ConfigurationValue;
            applicationConfiguration.OrganizationId = request.OrganizationId;
            applicationConfiguration.ApplicationCode = request.ApplicationCode;            

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
