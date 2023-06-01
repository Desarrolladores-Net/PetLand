using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO.Question;

namespace UseCases.InPorts
{
    public interface ICreateQuestionInport
    {
        Task Handle(CreateQuestionDTO dto);
    }
}