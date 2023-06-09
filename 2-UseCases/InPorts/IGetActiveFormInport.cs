using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;

namespace UseCases.InPorts
{
    public interface IGetActiveFormInport
    {
        Task Handle();
    }
}