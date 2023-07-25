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
    public class GetAllUsersPresenter : IPresenter<OneOf<List<GetAllUserResult>, Error>>, IGetAllUsersOutport
    {
        public OneOf<List<GetAllUserResult>, Error> Content {private set; get;}

        public Task Handle(OneOf<List<GetAllUserResult>, Error> result)
        {
            Content = result;
            return Task.CompletedTask;
        }
    }
}