using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Entity;
using Domain.ResultObject.Application;
using OneOf;
namespace UseCases.OutPorts
{
    public interface IGetApplicationsOutport
    {
        Task Handle(OneOf<GetApplicationsResult, Error> result);
    }
}