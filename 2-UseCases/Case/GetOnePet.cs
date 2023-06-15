using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Entity;
using Domain.Repositories;
using Domain.ResultObject.Pet;
using Mapster;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace UseCases.Case
{
    public class GetOnePet : IGetOnePetInport
    {
        private IUnitOfWork _unitOfWork;
        private IGetOnePetOutport _outport;

        public GetOnePet(IUnitOfWork unitOfWork, IGetOnePetOutport outport)
        {
            _unitOfWork = unitOfWork;
            _outport = outport;
        }

        public async Task Handle(string userId, string petId)
        {
            try
            {
                var entity = await _unitOfWork.PetRepository.GetOne(petId);

                var result = entity.Adapt<GetOnePetResult>();

                var application = await _unitOfWork.ApplicationRepository.AmIApproved(userId, petId);

                var user = await _unitOfWork.UserRepository.GetOne(userId);

                if (user.Role != "Admin")
                {

                    if (application == null)
                    {
                        result.Address = null;
                    }
                    else
                    {
                        if (application.ApplicationState != ApplicationState.Approved)
                        {
                            result.Address = null;
                        }
                    }
                }

                await _outport.Handle(result);

            }
            catch (System.Exception)
            {

                await _outport.Handle(new Error(ErrorReason.FailDatabase, "No se pudo conectar con la base de datos"));
            }
        }
    }
}