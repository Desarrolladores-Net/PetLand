using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO.Pet;
using Domain.DTO.User;

namespace UseCases.InPorts
{
    public interface ICreatePetInport
    {
        Task Handle(CreatePetDTO dto);
    }
}