using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ResultObject.Application
{
    public class GetApplicationsResult
    {
        public List<Domain.Entity.Application> Applications { get; set; }
        public int Quanty { get; set; }
    }
}