using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO.Form;
using Domain.Repositories;
using Domain.ResultObject.Form;
using Mapster;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace UseCases.Case
{
    public class ActiveForm : IActiveFormInport
    {
        private IUnitOfWork _unitOfWork;
        private IActiveFormOutport _outport;

        public ActiveForm(IUnitOfWork unitOfWork, IActiveFormOutport outport)
        {
            _unitOfWork = unitOfWork;
            _outport = outport;
        }

        public async Task Handle(ActiveFormDTO dto)
        {
            try
            {

                if (dto.OldId != null && dto.OldId != "")
                {
                    var oldForm = await _unitOfWork.FormRepository.GetOne(dto.OldId);
                    oldForm.Active = false;
                    await _unitOfWork.FormRepository.UpdateAsync(oldForm);
                }

                var newActive = await _unitOfWork.FormRepository.GetOne(dto.Id);
                newActive.Active = dto.Active;

                await _unitOfWork.FormRepository.UpdateAsync(newActive);
                await _unitOfWork.SaveAsync();
                var result = newActive.Adapt<ActiveFormResult>();

                await _outport.Handle(result);

            }
            catch (System.Exception ex)
            {
                await _outport.Handle(new Error(ErrorReason.FailDatabase, "Error al conectar con la base de datos"));
            }
        }
    }
}