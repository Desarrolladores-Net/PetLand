using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Pet> PetsReported { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Application> Application { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}