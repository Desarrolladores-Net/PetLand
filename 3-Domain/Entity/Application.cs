using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public enum ApplicationState{
        Pending,
        Denied,
        Approved
    }

    public class Application
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string PetId { get; set; }
        public DateTime Date { get; set; }
        public ApplicationState ApplicationState { get; set; }
        public List<UserResponse> UserResponse { get; set; }

    }
}