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
    public class FormRepository : IFormRepository
    {
        private AppDbContext _context;

        public FormRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Form entity)
        {
            _context.AddAsync(entity);
            return Task.CompletedTask;
        }

        public async Task<Form> Delete(int id)
        {
            var form = await _context.Form.FindAsync(id);
            _context.Remove(form);
            return form;
        }

        public Task<List<Form>> GetAll(int skip)
        {
            return _context.Form.Skip(skip).Take(10).ToListAsync();
        }

        public Task<List<Form>> GetAll()
        {
            return _context.Form.ToListAsync();
        }

        public Task<Form> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Form entity)
        {
            throw new NotImplementedException();
        }

    }
}