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
    public class PetsReportedRepository : IPetRepository
    {
        private AppDbContext _context;

        public PetsReportedRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Pet entity) => await _context.AddAsync(entity);

        public Task<int> Count()
        {
            return _context.PetsReported.Where(x => !x.WasAdopted).CountAsync();
        }

        public Task<int> Count(string province)
        {
            return _context.PetsReported.Include(x => x.Address).Where(x => x.Address.Province == province && !x.WasAdopted).CountAsync();
        }

        public Task<int> Count(string province, string municipality)
        {
            return _context.PetsReported.Include(x => x.Address).Where(x => x.Address.Province == province && x.Address.Municipe == municipality && !x.WasAdopted)
            .CountAsync();
        }

        public async Task<Pet> Delete(string id)
        {
            var pet = await _context.PetsReported.FindAsync(id);
            _context.Remove(pet!);
            return pet!;
        }

        public Task<List<Pet>> GetAll(int skip)
        {
            return _context.PetsReported.Include(x => x.Address).Where(x => !x.WasAdopted).Skip(skip).Take(10).ToListAsync();
        }

        public Task<List<Pet>> GetByProvince(int skip, string province)
        {
            return _context.PetsReported.Include(x => x.Address).Where(x => x.Address.Province == province && !x.WasAdopted)
            .Skip(skip).Take(10).ToListAsync();
        }

        public Task<List<Pet>> GetByProvince(int skip, string province, string municipality)
        {
            return _context.PetsReported.Include(x => x.Address).Where(x => x.Address.Province == province && x.Address.Municipe == municipality && !x.WasAdopted)
            .Skip(skip).Take(10).ToListAsync();
        }

        public Task<Pet> GetOne(string id) => _context.PetsReported.FindAsync(id).AsTask()!;


        public Task UpdateAsync(Pet entity)
        {
            _context.Update(entity);
            return Task.CompletedTask;
        }


        public Task<List<Pet>> GetAll()
        {
            return _context.PetsReported.ToListAsync();
        }
    }
}