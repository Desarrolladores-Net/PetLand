using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ResultObject.Form;
using OneOf;
namespace UseCases.OutPorts
{
    public interface ICreateFormOutport
    {
        Task Handle(OneOf<CreateFormResult, Error> result);
    }
}