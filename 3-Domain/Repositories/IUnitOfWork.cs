using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IPetRepository PetRepository { get; }
        IAddressRepository AddressRepository { get; }
        Task SaveAsync();
    }
}