using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class User
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public int phone { get; set; }
        public List<Pet> petsReported { get; set; }
        public string role { get; set; }
    }
}