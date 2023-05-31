using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTO.Form
{
    public class ActiveFormDTO
    {
        public string Id { get; set; }
        public string? OldId { get; set; }
        public bool Active { get; set; }
    }
}