using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ResultObject.Pet
{
    public class CreatePetResult
    {
        public string? Fullname { get; set; }
        public int? Age { get; set; }
        public string? Description { get; set; }
        public string Province { get; set; }
        public string Municipe { get; set; }
        public string StreetName { get; set; }
    }
}