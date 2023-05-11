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

        public async Task<Pet> Delete(int id)
        {
            var pet = await _context.PetsReported.FindAsync(id);
            _context.Remove(pet!);
            return pet!;
        }

        public Task<List<Pet>> GetAll(int skip)
        {
            return _context.PetsReported.Include(x => x.Address).Skip(skip).Take(10).ToListAsync();
        }

        public Task<Pet> GetOne(int id) => _context.PetsReported.FindAsync(id).AsTask()!;


        public Task UpdateAsync(Pet entity)
        {
            _context.Update(entity);
            return Task.CompletedTask;
        }
    }
}