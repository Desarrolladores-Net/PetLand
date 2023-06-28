using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO.User;

namespace UseCases.InPorts
{
    public interface ILoginInport
    {
        Task Handle(LoginDTO dto, string key);
    }
}