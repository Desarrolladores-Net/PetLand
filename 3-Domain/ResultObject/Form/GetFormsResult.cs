using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ResultObject.Form
{
    public class GetFormsResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}