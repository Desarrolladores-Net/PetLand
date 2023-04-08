using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseCases.OutPorts;

public interface IPetsRepository
{
    Task<dynamic> GetAllPetsAsync();
}
