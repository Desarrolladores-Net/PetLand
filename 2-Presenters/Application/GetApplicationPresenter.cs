using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ResultObject.Application;
using OneOf;
using UseCases.OutPorts;

namespace Presenters.Application
{
    public class GetApplicationPresenter : IPresenter<OneOf<GetApplicationsResult, Error>>, IGetApplicationsOutport
    {
        public OneOf<GetApplicationsResult, Error> Content {private set; get;}

        public Task Handle(OneOf<GetApplicationsResult, Error> result)
        {
            Content = result;
            return Task.CompletedTask;
        }
    }
}