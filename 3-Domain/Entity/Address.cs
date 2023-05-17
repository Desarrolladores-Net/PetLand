using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Domain.Entity
{
    public class Address
    {
        public string Id { get; set; }
        public string PetId { get; set; }
        public string Province { get; set; }
        public string Municipe { get; set; }
        public string StreetName { get; set; }
        public string? MoreDetails { get; set; }
    }
}