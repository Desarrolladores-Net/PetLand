using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseCases.OutPorts;
using OneOf;
using Domain.ResultObject.Form;
using Domain;

namespace Presenters.Form
{
    public class GetFormsPresenter :  IPresenter<OneOf<GetAllFormsResult, Error>>, IGetFormsOutport
    {
        public OneOf<GetAllFormsResult, Error> Content { private set; get; }

        public Task Handle(OneOf<GetAllFormsResult, Error> data)
        {
            Content = data;
            return Task.CompletedTask;
        }
    }
}