using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public List<Pet> PetsReported { get; set; }
        public string role { get; set; }
    }
}