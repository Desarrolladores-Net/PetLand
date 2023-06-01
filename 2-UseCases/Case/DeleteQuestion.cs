using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Repositories;
using Domain.ResultObject.Question;
using Mapster;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace UseCases.Case
{
    public class DeleteQuestion : IDeleteQuestionInport
    {
        private IUnitOfWork _unitOfWork;
        private IDeleteQuestionOutport _outport;

        public DeleteQuestion(IUnitOfWork unitOfWork, IDeleteQuestionOutport outport)
        {
            _unitOfWork = unitOfWork;
            _outport = outport;
        }

        public async Task Handle(string questionId)
        {
            try
            {
                var data = await _unitOfWork.QuestionRepository.Delete(questionId);
                await _unitOfWork.SaveAsync();
                var result = data.Adapt<GetQuestionResult>();
                await _outport.Handle(result);


            }
            catch (System.Exception ex)
            {
                await _outport.Handle(new Error(ErrorReason.FailDatabase, "Error al contextar con la base de datos"));
            }
        }
    }
}