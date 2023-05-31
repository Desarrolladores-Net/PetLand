using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ResultObject.Form;
using OneOf;
using UseCases.OutPorts;

namespace Presenters.Form
{
    public class UpdateFormPresenter : IPresenter<OneOf<UpdateFormResult, Error>>, IUpdateFormOutport
    {
        public OneOf<UpdateFormResult, Error> Content {private set; get;}

        public Task Handle(OneOf<UpdateFormResult, Error> result)
        {
            Content = result;
            return Task.CompletedTask;
        }
    }
}