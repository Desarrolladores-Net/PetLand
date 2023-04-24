using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ResultObject.Pet;
using OneOf;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UseCases.OutPorts
{
    public interface ICreatePetOutport
    {
        Task Handle(OneOf<CreatePetResult, Error> model);
    }
}