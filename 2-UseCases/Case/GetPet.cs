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
using Domain.Entity;

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

        public async Task Handle(int skip, string province, string municipality)
        {
            try
            {
                List<Pet> pets = new();
                if(province == "Todas")
                {
                    pets = await _unitOfWork.PetRepository.GetAll(skip);
                }
                else
                {
                    if(municipality == "Todos")
                    {
                        pets = await _unitOfWork.PetRepository.GetByProvince(skip, province);
                    }
                    else
                    {
                        pets = await _unitOfWork.PetRepository.GetByProvince(skip, province, municipality);
                    }

                    
                }
                

                var result = pets.Adapt<List<GetPetResult>>();


                await _outputPort.Handle(result);
            }
            catch (System.Exception ex)
            {

                await _outputPort.Handle(new Error(ErrorReason.FailDatabase, "Error al conectar con la base de datos"));
            }



        }
    }
}