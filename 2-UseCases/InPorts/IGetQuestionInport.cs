using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseCases.InPorts
{
    public interface IGetQuestionInport
    {
        Task Handle(string formId);
    }
}