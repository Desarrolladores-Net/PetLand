using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using OneOf;
using UseCases.OutPorts;

namespace Presenters.Form
{
    public class DeleteFormPresenter : IPresenter<OneOf<Domain.Entity.Form, Error>>, IDeleteFormOutport
    {
        public OneOf<Domain.Entity.Form, Error> Content {private set; get;}

        public Task Handle(OneOf<Domain.Entity.Form, Error> result)
        {
            Content = result;
            return Task.CompletedTask;
        }
    }
}