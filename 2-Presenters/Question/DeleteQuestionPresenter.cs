using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ResultObject.Question;
using OneOf;
using UseCases.OutPorts;

namespace Presenters.Question
{
    public class DeleteQuestionPresenter : IPresenter<OneOf<GetQuestionResult, Error>>, IDeleteQuestionOutport
    {
        public OneOf<GetQuestionResult, Error> Content {private set; get;}

        public Task Handle(OneOf<GetQuestionResult, Error>  result)
        {
            Content = result;
            return Task.CompletedTask;
        }
    }
}