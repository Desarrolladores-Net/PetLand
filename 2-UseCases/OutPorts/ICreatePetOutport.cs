using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ResultObject.Pet;
using OneOf;


namespace UseCases.OutPorts
{
    public interface ICreatePetOutport
    {
        Task Handle(OneOf<CreatePetResult, Error> model);
    }
}