using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra;
using Microsoft.Extensions.DependencyInjection;
using Presenters;
using Services;
using UseCases;

namespace IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMyServices(this IServiceCollection services, string connectionString)
        {
            services.AddPostgreSQL(connectionString);
            services.AddCustomServices();
            services.AddUseCases();
            services.AddPresenters();
            return services;
        }
    }
}