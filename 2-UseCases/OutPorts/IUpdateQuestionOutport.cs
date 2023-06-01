using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ResultObject.Question;
using OneOf;

namespace UseCases.OutPorts
{
    public interface IUpdateQuestionOutport
    {
        Task Handle(OneOf<GetQuestionResult, Error> result);
    }
}