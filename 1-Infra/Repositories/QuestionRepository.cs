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
    public class QuestionRepository : IQuestionRepository
    {
        private AppDbContext _context;

        public Task AddAsync(Question entity)
        {
            return _context.Question.AddAsync(entity).AsTask();

        }

        public async Task<Question> Delete(string id)
        {
            var result = await _context.Question.FindAsync(id);
            _context.Remove(result);
            return result;
        }

        public Task<List<Question>> GetAll(int skip)
        {
            return _context.Question.Skip(skip).Take(10).ToListAsync();
        }

        public Task<List<Question>> GetAll()
        {
            return _context.Question.ToListAsync();
        }

        public async Task<Question> GetOne(string id)
        {
            return _context.Question.FindAsync(id).AsTask().Result;
        }

        public Task UpdateAsync(Question entity)
        {
            _context.Update(entity);
            return Task.CompletedTask;
        }
    }
}