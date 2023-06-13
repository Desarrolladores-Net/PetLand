using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.ResultObject.Pet
{
    public class GetOnePetResult
    {
        public string Id { get; set; }
        public string? Fullname { get; set; }
        public int? Age { get; set; }
        public Address Address { get; set; }
        public string? Description { get; set; }
        public bool WasAdopted { get; set; }
        public DateTime? AdoptionDate { get; set; }
        public string PhotoPath { get; set; }
    }
}