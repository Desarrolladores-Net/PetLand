using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Repositories;
using Infra.Data;

namespace Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPetRepository Pet { get; }

        public IUserRepository User { get; }
        public IAddressRepository Address { get; }

        private AppDbContext _context;

        public UnitOfWork(IPetRepository Pet, IUserRepository User, IAddressRepository Address, AppDbContext _context)
        {
            Pet = Pet;
            User = User;
            Address = Address;
            _context = _context;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}