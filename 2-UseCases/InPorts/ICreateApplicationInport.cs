using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO.Application;

namespace UseCases.InPorts
{
    public interface ICreateApplicationInport
    {
        Task Handle(CreateApplicationDTO dto);
    }
}