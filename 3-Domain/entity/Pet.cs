using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Pet
    {
        [Key]
        public int userId { get; set; }
        public string? fullname { get; set; }
        public int? age { get; set; }
        public Address address { get; set; }
        public string? description { get; set; }
        public bool wasAdopted { get; set; }
        public DateTime adopcionDate { get; set; }


    }
}