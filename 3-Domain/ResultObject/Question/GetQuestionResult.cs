using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.ResultObject.Question
{
    public class GetQuestionResult
    {
        public string Id { get; set; }
        public string FormId { get; set; }
        public string Message { get; set; }
        public int Priority { get; set; }
        public TypeQuestion TypeQuestion { get; set; }
    }
}