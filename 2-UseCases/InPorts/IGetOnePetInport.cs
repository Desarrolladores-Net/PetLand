using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseCases.InPorts
{
    public interface IGetOnePetInport
    {
        Task Handle(string userId, string petId);
    }
}