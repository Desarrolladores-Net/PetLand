using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ResultObject.User
{
    public class GetAllUserResult
    {
        public List<GetAllUserItemResult> Users { get; set; }
        public int Quanty { get; set; }
    }
}