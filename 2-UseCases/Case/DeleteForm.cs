using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Repositories;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace UseCases.Case
{
    public class DeleteForm : IDeleteFormInport
    {
        private IUnitOfWork _unitOfWork;
        private IDeleteFormOutport _outport;

        public DeleteForm(IUnitOfWork unitOfWork, IDeleteFormOutport outport)
        {
            _unitOfWork = unitOfWork;
            _outport = outport;
        }

        public async Task Handle(string id)
        {
            try
            {
                var form = await _unitOfWork.FormRepository.Delete(id);
                await _unitOfWork.SaveAsync();

                await _outport.Handle(form);
            
            }
            catch (System.Exception ex)
            {
                
                await _outport.Handle(new Error(ErrorReason.FailDatabase, "Fallo al contectar con la base de datos"));
            }
        }
    }
}