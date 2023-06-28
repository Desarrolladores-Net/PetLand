using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ResultObject.User;
using OneOf;
using UseCases.OutPorts;

namespace Presenters.User
{
    public class LoginPresenter : IPresenter<OneOf<LoginResult, Error>>, ILoginOutport
    {
        public OneOf<LoginResult, Error> Content {private set; get;}

        public Task Handle(OneOf<LoginResult, Error> result)
        {
            Content = result;
            return Task.CompletedTask;
        }
    }
}