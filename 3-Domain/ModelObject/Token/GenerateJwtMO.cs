using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Domain.ModelObject.Token
{
    public class GenerateJwtMO
    {
        public List<Claim> Claims { get; set; }
        public string SecretKey { get; set; }
    }
}