using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string ApplicationId { get; set; }
        public string Question { get; set; }
        public string Response { get; set; }
        public int Priority { get; set; }
    }
}