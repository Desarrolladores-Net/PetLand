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
    public class GetOneApplication : IGetOneApplicationInport
    {
        private IUnitOfWork _unitOfWork;
        private IOneAppOutport _outport;

        public GetOneApplication(IUnitOfWork unitOfWork, IOneAppOutport outport)
        {
            _unitOfWork = unitOfWork;
            _outport = outport;
        }

        public async Task Handle(string applicationId)
        {
            try
            {
                var data = await _unitOfWork.ApplicationRepository.GetResponses(applicationId);

                await _outport.Handle(data);

            }
            catch (System.Exception ex)
            {
                
                await _outport.Handle(new Error(ErrorReason.FailDatabase, "Fallo al conectar con la base de datos"));
            }
        }
    }
}