using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public enum TypeQuestion{
        Simple,
        Long,
        YesOrNot
    }

    public class Question
    {
        public string Id { get; set; }
        public string FormId { get; set; }
        public string Message { get; set; }
        public int TypeQuestion { get; set; }
    }
}