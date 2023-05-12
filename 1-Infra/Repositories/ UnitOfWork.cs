using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Entity;
using Domain.Repositories;
using Infra.Data;

namespace Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPetRepository PetRepository { get; }

        public IUserRepository UserRepository { get; }
        public IAddressRepository AddressRepository { get; }

        private AppDbContext Context;

        public UnitOfWork(IPetRepository Pet, IUserRepository User, IAddressRepository Address, AppDbContext _context)
        {
            PetRepository = Pet;
            UserRepository = User;
            AddressRepository = Address;
            Context = _context;
        }
        public async Task SaveAsync()
        {
            try
            {
                 await Context.SaveChangesAsync();
            }
            catch(Exception error)
            {
                throw error;
            }
               
        }
    }
}