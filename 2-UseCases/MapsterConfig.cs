using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Entity;
using Domain.ResultObject;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace UseCases
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<RegisterDTO, User>.NewConfig();
            TypeAdapterConfig<User, RegisterResult>.NewConfig();
            
        }
    }
}