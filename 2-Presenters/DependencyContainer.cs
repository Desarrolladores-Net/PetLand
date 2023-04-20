using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Presenters.User;
using UseCases.OutPorts;

namespace Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {

            services.AddScoped<IRegisterUserOutport, RegisterUserPresenter>();
            

            return services;
        }
    }
}