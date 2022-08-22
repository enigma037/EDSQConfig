using EDSQConfig.Application.Common.Interface;
using EDSQConfig.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDSQConfig.Application.ConfigurationDefinitions.Commands
{
    public class UpdateConfigurationDefinitionHandler : IRequestHandler<UpdateConfigurationDefinitionCommand>
    {
        private readonly IEDSConfigDbContext _dbContext;

        public UpdateConfigurationDefinitionHandler(IEDSConfigDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public async Task<Unit> Handle(UpdateConfigurationDefinitionCommand request, CancellationToken cancellationToken)
        {
            var configurationDefinition = await _dbContext.ConfigurationDefinitions.FindAsync(request.Id);
            if (configurationDefinition == null)
            {
                throw new NotFoundException("Invalid ConfigurationDefinition id.");
            }

            configurationDefinition.ConfigurationType = request.ConfigurationType;
            configurationDefinition.ConfigurationDescription = request.ConfigurationDescription;
            configurationDefinition.DefaultValue = request.DefaultValue;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
