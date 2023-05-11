using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ResultObject.Pet
{
    public class GetPetResult
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; }
        public bool WasAdopted { get; set; }
        public DateTime AdoptionDate { get; set; }
    }
}