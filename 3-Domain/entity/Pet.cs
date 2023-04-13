using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Pet
    {

        public int id { get; set; }
        public int userId { get; set; }
        public string? fullname { get; set; }
        public int? age { get; set; }
        public Address address { get; set; }
        public string? description { get; set; }
        public bool wasAdopted { get; set; }
        public DateTime adoptionDate { get; set; }
    }
}