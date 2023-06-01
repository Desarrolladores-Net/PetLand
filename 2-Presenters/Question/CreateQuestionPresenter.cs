using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using OneOf;
using UseCases.OutPorts;

namespace Presenters.Question
{
    public class CreateQuestionPresenter : IPresenter<OneOf<Domain.Entity.Question, Error>>, ICreateQuestionOutport
    {
        public OneOf<Domain.Entity.Question, Error> Content {private set; get;}

        public Task Handle(OneOf<Domain.Entity.Question, Error> result)
        {
            Content = result;
            return Task.CompletedTask;
        }
    }
}