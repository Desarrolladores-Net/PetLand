using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseCases.OutPorts;

public interface IAuthService
{
    Task Authenticate(dynamic User);
}
