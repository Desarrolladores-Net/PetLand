using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Domain.DTO.Pet
{
    public class CreatePetDTO
    {
        public string UserId { get; set; }
        public string? Fullname { get; set; }
        public int? Age { get; set; }
        public string? Description { get; set; }
        public string Province { get; set; }
        public string Municipe { get; set; }
        public string StreetName { get; set; }
        public IFormFile Photo { get; set; }
    }
}