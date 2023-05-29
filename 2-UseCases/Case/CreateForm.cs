using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO.Form;
using Domain.Entity;
using Domain.Repositories;
using Domain.ResultObject.Form;
using Mapster;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace UseCases.Case
{
    public class CreateForm : ICreateFormInport
    {
        private IUnitOfWork _unitOfWork;
        private ICreateFormOutport _output;

        public CreateForm(IUnitOfWork unitOfWork, ICreateFormOutport output)
        {
            _unitOfWork = unitOfWork;
            _output = output;
        }

        public async Task Handle(CreateFormDTO dto)
        {
            try
            {
                var form = dto.Adapt<Form>();
                await _unitOfWork.FormRepository.AddAsync(form);
                await _unitOfWork.SaveAsync();
                
                await _output.Handle(new CreateFormResult{
                    Success = true
                });

            }
            catch (System.Exception ex)
            {
                await _output.Handle(new Error(ErrorReason.SaveEntity, "Ha habido un error a la hora de salvar el formulario"));
            }
        }


    }
}