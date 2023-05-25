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
    public class GetPetsPresenter : IPresenter<OneOf<GetAllPetResult, Error>>, IGetPetsOutport
    {
        public OneOf<GetAllPetResult, Error> Content {private set; get;}

        public Task Handle(OneOf<GetAllPetResult, Error> data)
        {
            Content = data;
            return Task.CompletedTask;
        }
    }
}