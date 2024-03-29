using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> Delete(string id);
        Task<T> GetOne(string id);
        Task<List<T>> GetAll(int skip);
        Task<List<T>> GetAll();

    }
}