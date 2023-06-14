using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Repositories
{
    public interface IApplicationRepository : IRepository<Application>
    {
        Task<Application> AmIApproved(string userId, string petId);
        Task<bool> ExistApplication(string userId, string petId);
        Task<List<Application>> GetAll(int skip, ApplicationState state);
        Task<int> Count();
        Task<Application> GetResponses(string applicationId);
    }
}