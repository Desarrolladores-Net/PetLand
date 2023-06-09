using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Entity;
using OneOf;

namespace UseCases.OutPorts
{
    public interface IGetActiveFormOutport
    {
        Task Handle(OneOf<Form, Error> result);
    }
}