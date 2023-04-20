using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Case;
using UseCases.InPorts;

namespace UseCases
{
    public static class DependencyContainer
    {

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {

            services.AddScoped<IRegisterUserInport, RegisterUser>();
            services.RegisterMapsterConfiguration();

            return services;
        }
    }
}