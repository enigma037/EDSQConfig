using MediatR;
using System;

namespace EDSQConfig.Application.ConfigurationDefinitions.Commands
{
    public class CreateConfigurationDefinitonCommand : IRequest
    {
        public string ConfigurationType { get; set; }
        public string ConfigurationDescription { get; set; }
        public string DefaultValue { get; set; }

    }
}
