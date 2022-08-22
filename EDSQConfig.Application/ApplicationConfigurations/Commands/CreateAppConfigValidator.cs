using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDSQConfig.Application.ApplicationConfigurations.Commands
{
    public class CreateAppConfigValidator : AbstractValidator<CreateAppConfigCommand>
    {
        public CreateAppConfigValidator()
        {
            RuleFor(c => c.ApplicationCode)
                .NotEmpty()
                .WithMessage("Code is required.")
                .MaximumLength(3)
                .WithMessage("Maximum Character Limit is 3.");
        }
    }
}
