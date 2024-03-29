using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO;
using Domain;
using OneOf;
using Domain.ResultObject;
using Domain.ResultObject.User;

namespace UseCases.OutPorts
{
    public interface IRegisterUserOutport
    {
        Task Handle(OneOf<RegisterResult, Error> Model);
    }
}