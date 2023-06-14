using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using OneOf;
using UseCases.OutPorts;

namespace Presenters.Application
{
    public class GetOneApplicationPresenter : IPresenter<OneOf<Domain.Entity.Application, Error>>, IOneAppOutport
    {
        public OneOf<Domain.Entity.Application, Error> Content {private set; get;}

        public Task Handle(OneOf<Domain.Entity.Application, Error> result)
        {
            Content = result;
            return Task.CompletedTask;
        }
    }
}