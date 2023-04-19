using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using Services.Token;

namespace Services
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            
            services.AddScoped<ITokenManager, TokenManager>();

            return services;
        }
    }
}