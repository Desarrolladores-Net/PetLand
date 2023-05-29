using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ResultObject.Form;
using UseCases.OutPorts;
using OneOf;
using Domain;

namespace Presenters.Form
{
    public class CreateFormPresenter : ICreateFormOutport, IPresenter<OneOf<CreateFormResult, Error>>
    {
        public OneOf<CreateFormResult, Error> Content {private set; get;}

        public Task Handle(OneOf<CreateFormResult, Error> result)
        {
            Content = result;
            return Task.CompletedTask;
        }
    }
}