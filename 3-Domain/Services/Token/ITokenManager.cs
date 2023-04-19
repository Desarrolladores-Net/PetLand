using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ModelObject.Token;

namespace Domain.Services.Token
{
    public interface ITokenManager
    {
        string GenerateJwt(GenerateJwtMO model);
    }
}