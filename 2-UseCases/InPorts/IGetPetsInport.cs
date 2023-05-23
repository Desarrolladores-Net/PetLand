using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseCases.InPorts
{
    public interface IGetPetsInport
    {
        Task Handle(int skip, string province, string municipality);
    }
}