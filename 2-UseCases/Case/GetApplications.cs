using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Entity;
using Domain.Repositories;
using Domain.ResultObject.Application;
using Domain.Services.Time;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace UseCases.Case
{
    public class GetApplications : IGetApplicationsInport
    {
        private IUnitOfWork _unitOfWork;
        private IGetApplicationsOutport _outport;
        private ITimeManager _timeManager;

        public GetApplications(IUnitOfWork unitOfWork, IGetApplicationsOutport outport, ITimeManager timeManager)
        {
            _unitOfWork = unitOfWork;
            _outport = outport;
            _timeManager = timeManager;
        }

        public async Task Handle(int skip, ApplicationState state)
        {
            
            try
            {
                var entity = await _unitOfWork.ApplicationRepository.GetAll(skip, state);

                foreach (var item in entity)
                {
                    item.Date = _timeManager.GetCubanTime(item.Date);
                }

                var result = new GetApplicationsResult()
                {
                    Applications = entity,
                    Quanty = await _unitOfWork.ApplicationRepository.Count(state)
                };

                await _outport.Handle(result);

            }
            catch (System.Exception ex)
            {              
                await _outport.Handle(new Error(ErrorReason.FailDatabase, "No se pudo establecer contacto con la base de datos"));
            }
        }
    }
}