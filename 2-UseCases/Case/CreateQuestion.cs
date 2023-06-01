using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO.Question;
using Domain.Entity;
using Domain.Repositories;
using Mapster;
using UseCases.InPorts;
using UseCases.OutPorts;

namespace UseCases.Case
{
    public class CreateQuestion : ICreateQuestionInport
    {
        private IUnitOfWork _unitOfWork;
        private ICreateQuestionOutport _outport;
 
        public CreateQuestion(IUnitOfWork unitOfWork, ICreateQuestionOutport outport)
        {
            _unitOfWork = unitOfWork;
            _outport = outport;
        }

        public async Task Handle(CreateQuestionDTO dto)
        {
            try
            {
                var question = dto.Adapt<Question>();

                await _unitOfWork.QuestionRepository.AddAsync(question);
                await _unitOfWork.SaveAsync();

                await _outport.Handle(question);

            }
            catch (System.Exception ex)
            {
                
                await _outport.Handle(new Error(ErrorReason.FailDatabase, "Ha habido un error al conectar con la base de datos"));
            }
        }
    }
}