using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ResultObject.Pet
{
    public class GetAllPetResult
    {
        public List<GetPetResult> info { get; set; }
        public int Quanty { get; set; }
    }
}