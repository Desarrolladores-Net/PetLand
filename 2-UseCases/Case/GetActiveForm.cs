using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Entity;
using Domain.Repositories;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace UseCases.Case
{
    public class GetActiveForm : IGetActiveFormInport
    {
        private IUnitOfWork _unitOfWork;
        private IGetActiveFormOutport _outport;

        public GetActiveForm(IUnitOfWork unitOfWork, IGetActiveFormOutport outport)
        {
            _unitOfWork = unitOfWork;
            _outport = outport;
        }

        public async Task Handle()
        {
            try
            {
                var result = await _unitOfWork.FormRepository.GetActive();    
                await _outport.Handle(result);
            }
            catch (System.Exception ex)
            {
                
                await _outport.Handle(new Error(ErrorReason.FailDatabase, "Error al conectar con la base de datos"));
            
            }
            
        }
    }
}