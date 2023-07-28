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
        public async Task AddAsync(User entity) => _context.AddAsync(entity);

        public async Task<User> Delete(string id)
        {
            var user = await _context.User.FindAsync(id);
            _context.Remove(user!);
            return user!;
        }

        public Task<bool> Exist(string email, string phone) => _context.User.AnyAsync(x => x.Email == email || x.Phone == phone);

        public Task<List<User>> GetAll(int skip)
        {
            return _context.User.Skip(skip).Take(10).ToListAsync();
        }

        public Task<int> Count()
        {
            return _context.User.CountAsync();
        }

        public Task<List<User>> GetAll()
        {
           return _context.User.ToListAsync();
        }

        public Task<List<User>> GetAll(int skip, int take)
        {
            return _context.User.OrderBy(x => x.Fullname).Skip(skip).Take(take).ToListAsync();
        }

        public Task<User> GetOne(string id) => _context.User.FindAsync(id).AsTask()!;

        public Task<User> SignIn(string value, string password)
        {
            return _context.User.Where(x => (x.Email == value || x.Phone == value) && x.Password == password).FirstOrDefaultAsync();
        }

        public Task UpdateAsync(User entity)
        {
            _context.Update(entity);
            return Task.CompletedTask;
        }
    }
}