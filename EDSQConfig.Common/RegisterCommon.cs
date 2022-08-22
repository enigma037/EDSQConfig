using EDSQConfig.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EDSQConfig.Common
{
    public static class RegisterCommon
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationExceptionBehavior<,>));            

            return services;
        }
    }
}
