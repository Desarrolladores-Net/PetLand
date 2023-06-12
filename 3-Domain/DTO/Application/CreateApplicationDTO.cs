using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTO.Application
{
    public class CreateApplicationDTO
    {
        public string UserId { get; set; }
        public string PetId { get; set; }
        public List<CreateUserResponseDTO> UserResponse { get; set; }
    }
}