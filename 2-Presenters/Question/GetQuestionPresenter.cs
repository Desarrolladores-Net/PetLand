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
    public class GetQuestionPresenter : IPresenter<OneOf<List<GetQuestionResult>, Error>>, IGetQuestionOutport
    {
        public OneOf<List<GetQuestionResult>, Error> Content {private set; get;}

        public Task Handle(OneOf<List<GetQuestionResult>, Error> result)
        {
            Content = result;
            return Task.CompletedTask;
        }
    }
}