using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ResultObject.Pet;
using OneOf;
using UseCases.OutPorts;

namespace Presenters.Pet
{
    public class GetOnePetPresenter : IPresenter<OneOf<GetOnePetResult, Error>>, IGetOnePetOutport
    {
        public OneOf<GetOnePetResult, Error> Content {private set; get;}

        public Task Handle(OneOf<GetOnePetResult, Error> result)
        {
            Content = result;
            return Task.CompletedTask;
        }
    }
}