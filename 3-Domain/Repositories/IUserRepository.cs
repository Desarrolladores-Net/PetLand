using Domain.Entity;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<bool> Exist(string email);
}
