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
    public class ApplicationRepository : IApplicationRepository
    {

        private AppDbContext _context;

        public ApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Application entity)
        {
            return _context.Application.AddAsync(entity).AsTask();
        }

        public Task<Application> AmIApproved(string userId, string petId)
        {
            return _context.Application.Where(x => x.UserId == userId && x.PetId == petId).FirstOrDefaultAsync();
        }

        public async Task<Application> Delete(string id)
        {
            var entity = await _context.Application.FindAsync(id);

            _context.Remove(entity);

            return entity;
        }

        public Task<List<Application>> GetAll(int skip)
        {
            return _context.Application.Skip(skip).Take(10).ToListAsync();
        }

        public Task<List<Application>> GetAll()
        {
            return _context.Application.ToListAsync();
        }

        public Task<Application> GetOne(string id)
        {
            return _context.Application.FindAsync(id).AsTask();
        }


        public Task UpdateAsync(Application entity)
        {
            _context.Application.Update(entity);
            return Task.CompletedTask;
        }

        public Task<bool> ExistApplication(string userId, string petId)
        {
            return _context.Application.AnyAsync(x => x.UserId == userId && x.PetId == petId);
        }
    }
}