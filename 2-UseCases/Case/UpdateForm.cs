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
    public class UpdateForm : IUpdateFormInport
    {
        private IUnitOfWork _unitOfWork;
        private IUpdateFormOutport _outport;

        public UpdateForm(IUnitOfWork unitOfWork, IUpdateFormOutport outport)
        {
            _unitOfWork = unitOfWork;
            _outport = outport;
        }

        public async Task Handle(UpdateFormDTO dto)
        {
            try
            {
                var form = await _unitOfWork.FormRepository.GetOne(dto.Id);

                form.Name = dto.Name;

                await _unitOfWork.FormRepository.UpdateAsync(form);

                await _unitOfWork.SaveAsync();
                var result = form.Adapt<UpdateFormResult>();

                await _outport.Handle(result);

            }
            catch (System.Exception ex)
            {
                await _outport.Handle(new Error(ErrorReason.FailDatabase, "Error al conectar con la base de datos"));
            }
        }
    }
}