using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO.Question;
using Domain.Repositories;
using Domain.ResultObject.Question;
using Mapster;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace UseCases.Case
{
    public class UpdateQuestion : IUpdateQuestionInport
    {
        private IUnitOfWork _unitOfWork;
        private IUpdateQuestionOutport _outport;

        public UpdateQuestion(IUnitOfWork unitOfWork, IUpdateQuestionOutport outport)
        {
            _unitOfWork = unitOfWork;
            _outport = outport;
        }

        public async Task Handle(UpdateQuestionDTO dto)
        {
            try
            {
                var data = await _unitOfWork.QuestionRepository.GetOne(dto.Id);
                data.Message = dto.Message;
                data.TypeQuestion = (int)dto.TypeQuestion;
                await _unitOfWork.QuestionRepository.UpdateAsync(data);
                await _unitOfWork.SaveAsync();

                var result = data.Adapt<GetQuestionResult>();

                await _outport.Handle(result);

            }
            catch (System.Exception ex)
            {

                await _outport.Handle(new Error(ErrorReason.FailDatabase, "Ha habido un error de conexión con la base de datos"));
            }

        }
    }
}