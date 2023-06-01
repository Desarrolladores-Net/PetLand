using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using UseCases.InPorts;
using UseCases.OutPorts;
using Mapster;
using Domain.ResultObject.Question;
using Domain;

namespace UseCases.Case
{
    public class GetQuestion : IGetQuestionInport
    {
        private IGetQuestionOutport _outport;
        private IUnitOfWork _unitOfWork;

        public GetQuestion(IGetQuestionOutport outport, IUnitOfWork unitOfWork)
        {
            _outport = outport;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(string formId)
        {
            try
            {
                var data = await _unitOfWork.QuestionRepository.GetAll(formId);
                var result = data.Adapt<List<GetQuestionResult>>();

                await _outport.Handle(result);

            }
            catch (System.Exception ex)
            {
                
                await _outport.Handle(new Error(ErrorReason.FailDatabase, "Error al conectar con la base de datos"));
            }
        }
    }
}