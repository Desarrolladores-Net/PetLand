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
    public class ActiveFormPresenter : IPresenter<OneOf<ActiveFormResult, Error>>, IActiveFormOutport
    {
        public OneOf<ActiveFormResult, Error> Content {private set; get;}

        public Task Handle(OneOf<ActiveFormResult, Error> result)
        {
            Content = result;
            return Task.CompletedTask;
        }
    }
}