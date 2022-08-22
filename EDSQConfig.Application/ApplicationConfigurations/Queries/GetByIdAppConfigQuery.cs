using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDSQConfig.Application.ApplicationConfigurations.Queries
{
    public class GetByIdAppConfigQuery : IRequest<GetByIdAppConfigResponse>
    {
        public int Id { get; set; }
    }
}
