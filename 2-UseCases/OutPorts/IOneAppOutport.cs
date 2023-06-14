using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Entity;
using OneOf;
namespace UseCases.OutPorts
{
    public interface IOneAppOutport
    {
        Task Handle(OneOf<Application, Error> result);
    }
}