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
            services.AddScoped<IGetPetsInport, GetPet>();
            services.AddScoped<ICreatePetInport, CreatePet>();
            services.AddScoped<ICreateFormInport, CreateForm>();
            services.AddScoped<IGetFormsInport, GetForms>();
            services.AddScoped<IUpdateFormInport, UpdateForm>();
            services.AddScoped<IActiveFormInport, ActiveForm>();
            services.AddScoped<IDeleteFormInport, DeleteForm>();
            services.AddScoped<ICreateQuestionInport, CreateQuestion>();
            services.AddScoped<IGetQuestionInport, GetQuestion>();
            services.RegisterMapsterConfiguration();

            return services;
        }
    }
}