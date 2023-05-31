using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO.Form;
using Domain.ResultObject.Form;
using OneOf;

namespace UseCases.OutPorts
{
    public interface IUpdateFormOutport
    {
        Task Handle(OneOf<UpdateFormResult, Error> result);
    }
}