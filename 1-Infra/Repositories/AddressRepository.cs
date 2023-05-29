using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Repositories;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Address entity) => _context.AddAsync(entity).AsTask();

        public async Task<Address> Delete(int id)
        {
            var address = await _context.Address.FindAsync(id);
            _context.Remove(address!);
            return address!;
        }

        public Task<List<Address>> GetAll(int skip)
        {
            return _context.Address.Skip(skip).Take(10).ToListAsync();
        }

        public Task<List<Address>> GetAll()
        {
            return _context.Address.ToListAsync();
        }

    

        public Task<Address> GetOne(int id) => _context.Address.FindAsync(id).AsTask()!;

        public Task UpdateAsync(Address entity)
        {
            _context.Update(entity);
            return Task.CompletedTask;
        }
    }
}