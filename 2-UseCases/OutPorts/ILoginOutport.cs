using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ResultObject.User;
using OneOf;
namespace UseCases.OutPorts
{
    public interface ILoginOutport
    {
        Task Handle(OneOf<LoginResult, Error> result);
    }
}