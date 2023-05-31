using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ResultObject.Form
{
    public class GetAllFormsResult
    {
        public List<GetFormsResult> Data { get; set; }
        public int Count { get; set; }
    }
}