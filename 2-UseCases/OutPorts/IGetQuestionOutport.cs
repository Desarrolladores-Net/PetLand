using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ResultObject.Question;
using OneOf;

namespace UseCases.OutPorts
{
    public interface IGetQuestionOutport
    {
        Task Handle(OneOf<List<GetQuestionResult>, Error> result);
    }
}