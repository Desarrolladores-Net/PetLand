using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.DTO.User;

namespace UseCases.InPorts
{
    public interface IRegisterUserInport
    {
        Task Handle(RegisterDTO dto, string secretKey);
    }
}