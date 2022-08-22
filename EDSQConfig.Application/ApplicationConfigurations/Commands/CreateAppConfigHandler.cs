using EDSQConfig.Application.Common.Interface;
using EDSQConfig.Domain.Entities.EDSConfig;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EDSQConfig.Application.ApplicationConfigurations.Commands
{
    public class CreateAppConfigHandler : IRequestHandler<CreateAppConfigCommand>
    {
        private readonly IEDSConfigDbContext _dbContext;

        public CreateAppConfigHandler(IEDSConfigDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateAppConfigCommand request, CancellationToken cancellationToken)
        {
            var appConfiguration = new ApplicationConfiguration
            {
                ApplicationCode = request.ApplicationCode,
                ConfigurationDefinitionId = request.ConfigurationDefinitionId,
                ConfigurationValue = request.ConfigurationValue,
            };
            _dbContext.ApplicationConfigurations.Add(appConfiguration);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;


        }
    }
}
