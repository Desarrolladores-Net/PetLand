using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.DTO.Application
{
    public class SetApplicationStateDTO
    {
        public string ApplicationId { get; set; }
        public ApplicationState State { get; set; }
    }
}