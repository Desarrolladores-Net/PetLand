using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Presenters.Form;
using Presenters.Pet;
using Presenters.Pet;
using Presenters.User;
using UseCases.Case;
using UseCases.Case;
using UseCases.OutPorts;

namespace Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {

            services.AddScoped<IRegisterUserOutport, RegisterUserPresenter>();
            services.AddScoped<IGetPetsOutport, GetPetsPresenter>();
            services.AddScoped<ICreatePetOutport, CreatePetPresenter>();
            services.AddScoped<ICreateFormOutport, CreateFormPresenter>();
            services.AddScoped<IGetFormsOutport, GetFormsPresenter>();
            services.AddScoped<IUpdateFormOutport, UpdateFormPresenter>();
            services.AddScoped<IActiveFormOutport, ActiveFormPresenter>();
            services.AddScoped<IDeleteFormOutport, DeleteFormPresenter>();
            return services;
        }
    }
}