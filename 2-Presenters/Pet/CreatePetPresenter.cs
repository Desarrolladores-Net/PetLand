using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using Domain;
using Domain.ResultObject.Pet;
using OneOf;
using UseCases.OutPorts;

namespace Presenters.Pet
{
    public class CreatePetPresenter : IPresenter<OneOf<CreatePetResult, Error>>, ICreatePetOutport
    {
        public OneOf<CreatePetResult, Error> Content {private set; get;}

        public Task Handle(OneOf<CreatePetResult, Error> model)
        {
            Content = model;
            return Task.CompletedTask;
        }
    }
}