using Domain.Entity;

namespace Domain.Repositories
{
    public interface IPetRepository : IRepository<Pet>
    {
        Task<List<Pet>> GetByProvince(int skip, string province, string municipality);
        Task<List<Pet>> GetByProvince(int skip, string province);
        Task<int> Count();
        Task<int> Count(string province);
        Task<int> Count(string province, string municipality);
        
    }
}