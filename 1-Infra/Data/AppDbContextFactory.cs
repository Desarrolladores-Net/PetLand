using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Repositories;
using Infra.Data;
using Infra.Repositories;


namespace Infra.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var OptionBuilder = new DbContextOptionsBuilder<AppDbContext>();
         

            OptionBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=petland;User Id=postgres;Password=9902;");

            return new AppDbContext(OptionBuilder.Options);


        



        }
    }
}