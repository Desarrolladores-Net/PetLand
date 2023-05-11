using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using Domain.ResultObject.Pet;
using Mapster;
using UseCases.InPorts;
using UseCases.OutPorts;
using OneOf;
using Domain;

namespace UseCases.Case
{
    public class GetPet : IGetPetsInport
    {
        private IUnitOfWork _unitOfWork;
        private IGetPetsOutport _outputPort;

        public GetPet(IUnitOfWork unitOfWork, IGetPetsOutport outputPort)
        {
            _unitOfWork = unitOfWork;
            _outputPort = outputPort;
        }

        public async Task Handle(int skip)
        {
            try
            {
                var pets = await _unitOfWork.PetRepository.GetAll(skip);

                var result = pets.Adapt<List<GetPetResult>>();


                await _outputPort.Handle(result);
            }
            catch (System.Exception ex)
            {

                await _outputPort.Handle(new Error(ErrorReason.))
            }



        }
    }
}