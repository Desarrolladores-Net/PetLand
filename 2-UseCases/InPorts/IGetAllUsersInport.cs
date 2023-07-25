using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO.User;
using Domain.ResultObject.User;
using OneOf;

namespace UseCases.InPorts
{
    public interface IGetAllUsersInport
    {
        Task Handle(GetAllUserDTO dto);
    }
}