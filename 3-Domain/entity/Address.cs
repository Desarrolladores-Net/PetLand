using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Address
    {
        public int id { get; set; }
        public int petId { get; set; }
        public string province { get; set; }
        public string municipe { get; set; }
        public string streetName { get; set; }
    }
}