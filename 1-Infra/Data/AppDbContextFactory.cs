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
         
            var connection = "Server=localhost;Port=3308;Database=petland;Uid=root;Pwd=9902;";
            //var connection = "Server=mysql5048.site4now.net;Database=db_a9b805_petland;Uid=a9b805_petland;Pwd=brianpl990227;";
            //var connection = "Host=dpg-cie9ee6nqql22eg9pp80-a.oregon-postgres.render.com;Database=petlanddb;User Id=brianpl990227;Password=IWNLqbZcqHiZ2KfngiFHxIEfkOv0ZOhD; Trust Server Certificate=true;";
            OptionBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
            //OptionBuilder.UseNpgsql(connection);
            return new AppDbContext(OptionBuilder.Options);


        }
    }
}