using Domain.Entity;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<bool> Exist(string email, string phone);
    Task<User> SignIn(string value, string password);
    Task<List<User>> GetAll(int skip, int take);
}
