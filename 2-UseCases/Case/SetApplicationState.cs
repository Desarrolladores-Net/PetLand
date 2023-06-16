using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO.Application;
using Domain.Repositories;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace UseCases.Case
{
    public class SetApplicationState : ISetApplicationStateInport
    {
        private IUnitOfWork _unitOfWork;
        private ISetApplicationStateOutport _outport;

        public SetApplicationState(IUnitOfWork unitOfWork, ISetApplicationStateOutport outport)
        {
            _unitOfWork = unitOfWork;
            _outport = outport;
        }

        public async Task Handle(SetApplicationStateDTO dto)
        {
            try
            {
                var entity = await _unitOfWork.ApplicationRepository.GetOne(dto.ApplicationId);
                entity.ApplicationState = dto.State;
                await _unitOfWork.ApplicationRepository.UpdateAsync(entity);
                await _unitOfWork.SaveAsync();

                await _outport.Handle(entity);

            }
            catch (System.Exception)
            {
                
                await _outport.Handle(new Error(ErrorReason.FailDatabase, "Fallo al conectar con la base de datos"));
            }
        }
    }
}