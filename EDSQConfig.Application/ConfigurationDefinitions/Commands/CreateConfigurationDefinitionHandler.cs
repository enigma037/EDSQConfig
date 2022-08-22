using EDSQConfig.Application.Common.Interface;
using EDSQConfig.Domain.Entities.EDSConfig;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDSQConfig.Application.ConfigurationDefinitions.Commands
{
    public class CreateConfigurationDefinitionHandler : IRequestHandler<CreateConfigurationDefinitonCommand>
    {
        readonly IEDSConfigDbContext _dbContext;
        public CreateConfigurationDefinitionHandler(IEDSConfigDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(CreateConfigurationDefinitonCommand request, CancellationToken cancellationToken)
        {
            var configDefinition = new ConfigurationDefinition
            {
                ConfigurationType = request.ConfigurationType,
                ConfigurationDescription = request.ConfigurationDescription,
                DefaultValue = request.DefaultValue,
            };
            _dbContext.ConfigurationDefinitions.Add(configDefinition);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
