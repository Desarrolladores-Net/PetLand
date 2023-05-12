using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.DTO.Pet;
using Domain.DTO.User;
using Domain.Entity;
using Domain.ResultObject;
using Domain.ResultObject.Pet;
using Domain.ResultObject.User;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace UseCases
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<RegisterDTO, User>.NewConfig().Map(dest => dest.Id, () => Guid.NewGuid().ToString());
            TypeAdapterConfig<User, RegisterResult>.NewConfig();
            TypeAdapterConfig<Pet, GetPetResult>.NewConfig()
            .Map(dest => dest.Address, src => $"{src.Address.StreetName}, {src.Address.Municipe}, {src.Address.Province}, {src.Address.MoreDetails}");
            TypeAdapterConfig<CreatePetDTO, Pet>.NewConfig()
            .Map(dest => dest.Id, () => Guid.NewGuid().ToString())
            .Map(dest => dest.Address, source => new Address()
            {
                Municipe = source.Municipe,
                Province = source.Province,
                StreetName = source.StreetName,
                Id = Guid.NewGuid().ToString()
            });
            TypeAdapterConfig<Pet, CreatePetResult>.NewConfig();
            
        }
    }
}