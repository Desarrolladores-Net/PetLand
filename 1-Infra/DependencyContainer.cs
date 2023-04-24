using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Domain.Services.ExternalServices;
using Dropbox.Api;
using Infra.Data;
using Infra.ExternalServices;
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



            return services;
        }

        public static IServiceCollection AddDrobox(this IServiceCollection services, string dropboxToken)
        {
            services.AddScoped<IDropboxManager, DropboxManager>();
            services.AddScoped<DropboxClient>(serviceProvider => new DropboxClient(dropboxToken));

            return services;

        }


    }
}