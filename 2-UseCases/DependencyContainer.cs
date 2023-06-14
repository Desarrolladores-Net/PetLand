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
            services.RegisterMapsterConfiguration();
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
            services.AddScoped<IDeleteQuestionInport, DeleteQuestion>();
            services.AddScoped<IUpdateQuestionInport, UpdateQuestion>();
            services.AddScoped<IGetActiveFormInport, GetActiveForm>();
            services.AddScoped<ICreateApplicationInport, CreateApplication>();
            services.AddScoped<IGetOnePetInport, GetOnePet>();
            services.AddScoped<IGetApplicationsInport, GetApplications>();
            services.AddScoped<IGetOneApplicationInport, GetOneApplication>();

            return services;
        }
    }
}