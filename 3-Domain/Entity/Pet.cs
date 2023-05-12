using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Pet
    {

        public string Id { get; set; }
        public string UserId { get; set; }
        public string? Fullname { get; set; }
        public int? Age { get; set; }
        public Address Address { get; set; }
        public string? Description { get; set; }
        public bool WasAdopted { get; set; }
        public DateTime AdoptionDate { get; set; }
    }
}