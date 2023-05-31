using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseCases.InPorts
{
    public interface IDeleteFormInport
    {
        Task Handle(string id);
    }
}