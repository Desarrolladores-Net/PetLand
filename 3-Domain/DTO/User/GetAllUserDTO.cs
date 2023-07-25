using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTO.User
{
    public class GetAllUserDTO
    {
        [Range(1, int.MaxValue)]
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}