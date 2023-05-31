using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Repositories;
using Domain.ResultObject.Form;
using Mapster;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace UseCases.Case
{
    public class GetForms : IGetFormsInport
    {
        private IUnitOfWork _unitOfWork;
        private IGetFormsOutport _outport;

        public GetForms(IUnitOfWork unitOfWork, IGetFormsOutport outport)
        {
            _unitOfWork = unitOfWork;
            _outport = outport;
        }

        public async Task Handle()
        {
            try
            {
                var data = await _unitOfWork.FormRepository.GetAll();
                var result = data.Adapt<List<GetFormsResult>>();

                GetAllFormsResult forms = new()
                {
                    Data = result,
                    Count = result.Count
                };

                await _outport.Handle(forms);

            }
            catch (System.Exception ex)
            {
                
                await _outport.Handle(new Error(ErrorReason.FailDatabase, "Error al conectar con la base de datos"));
            }
        }
    }
}