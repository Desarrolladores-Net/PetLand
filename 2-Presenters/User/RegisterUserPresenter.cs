using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO;
using Domain;
using OneOf;
using UseCases.OutPorts;
using Domain.ResultObject;

namespace Presenters.User
{
    public class RegisterUserPresenter : IPresenter<OneOf<RegisterResult, Error>>, IRegisterUserOutport
    {
        public OneOf<RegisterResult, Error>  Content {private set; get;}

        public Task Handle(OneOf<RegisterResult, Error> Model)
        {
            Content = Model;
            return Task.CompletedTask;
        }
    }
}