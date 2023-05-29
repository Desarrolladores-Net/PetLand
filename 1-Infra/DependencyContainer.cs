using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Domain.Services.Files;
using Infra.Data;
using Infra.Files;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class DependencyContainer
    {

        public static IServiceCollection AddPostgreSQL(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPetRepository, PetsReportedRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IFileManager, FileManager>();
            services.AddScoped<IFormRepository, FormRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();

            return services;
        }




    }
}