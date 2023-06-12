using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.DTO.Application;
using Domain.DTO.Form;
using Domain.DTO.Pet;
using Domain.DTO.Question;
using Domain.DTO.User;
using Domain.Entity;
using Domain.ResultObject;
using Domain.ResultObject.Form;
using Domain.ResultObject.Pet;
using Domain.ResultObject.Question;
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
            TypeAdapterConfig<Pet, GetPetResult>.NewConfig();
            TypeAdapterConfig<CreatePetDTO, Pet>.NewConfig()
            .Map(dest => dest.Id, () => Guid.NewGuid().ToString())
            .Map(dest => dest.Address, source => new Address()
            {
                Municipe = source.Municipe,
                Province = source.Province,
                StreetName = source.StreetName,
                Id = Guid.NewGuid().ToString(),
                MoreDetails = source.MoreDetails
            });
            TypeAdapterConfig<Pet, CreatePetResult>.NewConfig();
            TypeAdapterConfig<CreateFormDTO, Form>.NewConfig()
            .Map(x => x.Id, () => Guid.NewGuid().ToString());
            TypeAdapterConfig<Form, GetFormsResult>.NewConfig();
            TypeAdapterConfig<Form, UpdateFormResult>.NewConfig();
            TypeAdapterConfig<Form, ActiveFormResult>.NewConfig();
            TypeAdapterConfig<CreateQuestionDTO, Question>.NewConfig()
            .Map(dest => dest.Id, () => Guid.NewGuid().ToString());
            TypeAdapterConfig<Question, GetQuestionResult>.NewConfig();

            TypeAdapterConfig<CreateApplicationDTO, Application>.NewConfig()
            .Map(dest => dest.Id, Guid.NewGuid().ToString());
            
        }
    }
}