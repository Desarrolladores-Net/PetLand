using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO.Form;

namespace UseCases.InPorts
{
    public interface ICreateFormInport
    {
        Task Handle(CreateFormDTO dto);
    }
}