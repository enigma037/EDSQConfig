using EDSQConfig.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EDSQConfig.Application.Common.Interface;

namespace EDSQConfig.Infrastructure
{
    public static class RegisterInfrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                          IConfiguration configuration)
        {
            
            services.AddDbContext<IEDSConfigDbContext, EDSConfigDbContext>(options =>
            {

                options.UseSqlServer(configuration.GetConnectionString("EDSConfig"));
                

            });

            return services;




        }
    }
}
