using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDSQConfig.Application.ConfigurationDefinitions.Commands
{
    public class CreateConfigurationDefinitonValidator : AbstractValidator<CreateConfigurationDefinitonCommand>
    {
        public CreateConfigurationDefinitonValidator()
        {
            RuleFor(r => r.ConfigurationType)
                .NotEmpty()
                .WithMessage("ConfigurationType is required.")
                .MaximumLength(50)
                .WithMessage("Maximum character limit is 50.");

            RuleFor(r => r.ConfigurationDescription)
                .MaximumLength(500)
                .WithMessage("Maximum character limit is 500.");

            RuleFor(r=> r.DefaultValue)
                .MaximumLength(256)
                .WithMessage("Maximum character limit is 256.");

        }
    }
}
