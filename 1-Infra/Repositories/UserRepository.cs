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
    public class UserRepository : IUserRepository
    {
        private AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User entity) => await _context.AddAsync(entity);

        public async Task<User> Delete(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.Remove(user!);
            return user!;
        }

        public Task<List<User>> GetAll() => _context.User.ToListAsync();

        public Task<User> GetOne(int id) => _context.User.FindAsync(id).AsTask()!;


        public Task UpdateAsync(User entity)
        {
            _context.Update(entity);
            return Task.CompletedTask;
        }
    }
}